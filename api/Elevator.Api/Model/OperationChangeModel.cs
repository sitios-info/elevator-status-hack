namespace Elevator.Api.Model;

public class OperationChangeModel
{
    public required OperationStatus OperationStatus { get; init; }
    public required string Reason { get; init; } = "";
    
    public DateTime TimeStamp { get; set; }
    public required MetaDataSourceInfoModel? MetaDataSourceInfo { get; set; }
}