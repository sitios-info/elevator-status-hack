namespace Elevator.Api.Model;

public class ElevatorCreateModel
{
    public Guid? OpenStreetMapId { get; init; }

    public Dictionary<string, string>? Properties { get; init; }

    public GeoLocationCreateModel? Location { get; init; }
    
    public string? ManufacturerName { get; init; }

    public string? SerialNumber { get; init; }

    public OperatorCreateModel? Operator { get; init; }
}