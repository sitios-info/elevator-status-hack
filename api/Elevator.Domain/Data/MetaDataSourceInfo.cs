namespace Elevator.Domain.Data;

public class MetaDataSourceInfo
{
    public Guid Id { get; set; }
    public string? License { get; set; }
    public DateTime? TimeStamp { get; set; }
    public string? SourceType { get; set; }
}