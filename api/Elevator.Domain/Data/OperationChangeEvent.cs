namespace Elevator.Domain.Data;

public class OperationChangeEvent
{
    public Guid Id { get; set; }
    public DateTime ChangedTime { get; set; }
    public string Reason { get; set; }
    public string OperationMode { get; set; }
}