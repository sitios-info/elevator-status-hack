namespace Elevator.Domain.Data;

public class PlannedMaintenance
{
    public Guid Id { get; init; }
    public required string Description { get; init; }
    public required DateTime Start { get; init; }
    public required DateTime End { get; init; }
    public string? Reason { get; init; }
    public required string? ExpectedOperationStatus { get; init; }
    public required Elevator Elevator { get; init; }
}