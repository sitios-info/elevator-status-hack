namespace Elevator.Domain;

using Data;

public static class DummyData
{
    public static Elevator DummyElevator1
    {
        get
        {
            return new Elevator
            {
                Id = Guid.NewGuid(),
                Events = ArraySegment<OperationChangeEvent>.Empty,
                Location = null,
                ManufacturerName = "Bosch",
                MetaDataSourceInfo = null,
                OpenStreetMapId = null,
                Operator = null,
                Properties = new Dictionary<string, string>(),
                SerialNumber = "A-1732-B-"
            };
        }
    }
}