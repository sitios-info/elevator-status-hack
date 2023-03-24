namespace Elevator.Domain.Data;

public class MetaDataSourceInfo
{
    public Guid Id { get; init; }
    public string? License { get; init; }
    public DateTime? TimeStamp { get; init; }
    public string? SourceType { get; init; }
}