namespace Elevator.Api.Model;

public class PlannedMaintenanceModel
{
    public Guid Id { get; init; }
    public required string Description { get; init; }
    public required DateTime Start { get; init; }
    public required DateTime End { get; init; }
    public string? Reason { get; init; }
}