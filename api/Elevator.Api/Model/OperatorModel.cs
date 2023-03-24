namespace Elevator.Api.Model;

public class OperatorModel
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required string ContactEmail { get; init; }

    public required string ContactPhone { get; init; }
}