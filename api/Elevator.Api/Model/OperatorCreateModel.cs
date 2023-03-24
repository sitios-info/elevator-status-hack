namespace Elevator.Api.Model;

public class OperatorCreateModel
{
    public required string Name { get; init; }

    public string? ContactEmail { get; init; }

    public string? ContactPhone { get; init; }
}