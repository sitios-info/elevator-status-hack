// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var url = "https://accessibility-cloud-v2.freetls.fastly.net/";
        var count = 15;
        var requestUrl = $"equipment-infos.json?appToken=99613c884ebf63b848a6ef16441bcedc&limit={count}&includeRelated=placeInfo";

        var client = new RestClient(url);
        var request = new RestRequest(requestUrl);
        var response = await client.GetAsync(request);

        var jResults = JObject.Parse(response.Content);

        foreach (var feature in jResults["features"])
        {
            var properties = feature["properties"];

            if ((string)properties["category"] != "elevator")
                continue;

            if (properties["isWorking"] == null)
                continue;

            var coordinates = feature["geometry"]["coordinates"];
            var longitude = (decimal)coordinates[0];
            var latitude = (decimal)coordinates[1];

            var description = (string)properties["description"];
            var organizationName = (string)properties["organizationName"];
            var lastUpdate = (string)properties["lastUpdate"];
            var isWorking = (bool)properties["isWorking"];

            var placeInfoId = (string)properties["placeInfoId"];
            var place = ((IEnumerable<KeyValuePair<string, JToken>>)jResults["related"]["placeInfos"]).Where(_ => _.Key == placeInfoId).Select(_ => _.Value).Cast<JObject>().First();
            var placeProperties = place["properties"];
            var adressText = (string)placeProperties["name"]["de"];

            // TODO: do something nice
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
        }
    }
}
