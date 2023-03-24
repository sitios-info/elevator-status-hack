namespace Elevator.Domain.Data;

public class Operator
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string ContactEmail { get; init; }
    public required string ContactPhone { get; init; }
}