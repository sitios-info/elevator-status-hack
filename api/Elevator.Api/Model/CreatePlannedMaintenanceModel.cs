namespace Elevator.Api.Model;

public class CreatePlannedMaintenanceModel
{
    public Guid ElevatorId { get; init; }
    public required string Description { get; init; }
    public required string? ExpectedOperationStatus { get; init; }
    public required DateTime Start { get; init; }
    public required DateTime End { get; init; }
    public string? Reason { get; init; }
}