namespace Elevator.Domain.Data;

public class OperationChangeEvent
{
    public Guid Id { get; init; }
    public required DateTime ChangedTime { get; init; }
    public required string Reason { get; init; }
    public required string OperationMode { get; init; }
    public required Elevator Elevator { get; init; }
    public MetaDataSourceInfo? MetaDataSourceInfo { get; init; } 
}