namespace Elevator.Api.Model;

public class OperationChangeModel
{
    public required OperationStatus OperationStatus { get; init; }
    public required string Reason { get; init; } = "";
}