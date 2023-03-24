namespace Elevator.Api.Model;

public class GeometryModel
{
    public required string Type { get; init; }

    public required double[] Coordinates { get; init; }
}