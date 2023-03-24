// See https://aka.ms/new-console-template for more information

using ElevatorApiClient;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Globalization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var sourceUrl = "https://accessibility-cloud-v2.freetls.fastly.net/";
        var count = 30;
        var requestUrl = $"equipment-infos.json?appToken=99613c884ebf63b848a6ef16441bcedc&limit={count}&includeRelated=placeInfo";
        var apiUrl = "http://localhost:5028";

        var client = new RestClient(sourceUrl);
        var request = new RestRequest(requestUrl);
        var response = await client.GetAsync(request);
        var httpClient = new HttpClient();

        var jResults = JObject.Parse(response.Content);

        foreach (var feature in jResults["features"])
        {
            var properties = feature["properties"];

            if ((string)properties["category"] != "elevator")
                continue;

            if (properties["isWorking"] == null)
                continue;

            var coordinates = feature["geometry"]["coordinates"];
            var longitude = (double)coordinates[0];
            var latitude = (double)coordinates[1];

            var description = (string)properties["description"];
            var organizationName = (string)properties["organizationName"];
            var lastUpdate = DateTime.Parse((string)properties["lastUpdate"], CultureInfo.InvariantCulture);
            var isWorking = (bool)properties["isWorking"];

            var placeInfoId = (string)properties["placeInfoId"];
            var place = ((IEnumerable<KeyValuePair<string, JToken>>)jResults["related"]["placeInfos"]).Where(_ => _.Key == placeInfoId).Select(_ => _.Value).Cast<JObject>().First();
            var placeProperties = place["properties"];
            var adressText = (string)placeProperties["name"]["de"];

            // dump data
            var elevatorEntry = new
            {
                longitude,
                latitude,
                adressText,
                description,
                organizationName,
                lastUpdate,
                isWorking
            };
            Console.WriteLine(elevatorEntry);

            var apiClient = new Client(apiUrl, httpClient);

            var model = new ElevatorCreateModel
            {
                Location = new GeoLocationCreateModel
                {
                    AddressText = adressText,
                    Geometry = new GeometryCreateModel
                    {
                        Coordinates = new[] { longitude, latitude }
                    }
                },
                Operator = new OperatorCreateModel
                {
                    Name = organizationName
                }
            };
            var elevatorModel = await apiClient.ElevatorsPOSTAsync(model);

            var operationChangeModel = new OperationChangeModel
            {
                OperationStatus = isWorking ? OperationStatus.InService : OperationStatus.NotOperational,
                TimeStamp = new DateTimeOffset(lastUpdate),
                Reason = "Unknown",
                MetaDataSourceInfo = new MetaDataSourceInfoModel()
            };
            await apiClient.OperationChangePOSTAsync(elevatorModel.Id,operationChangeModel);
        }
    }

}
