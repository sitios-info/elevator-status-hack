namespace Elevator.Domain.Data;

public class OperationChangeEvent
{
    public required Guid Id { get; init; }
    public required DateTime ChangedTime { get; init; }
    public required string Reason { get; init; }
    public required string OperationMode { get; init; }
}