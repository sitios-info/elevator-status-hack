namespace Elevator.Api.Model;

public class OperationChangeModel
{
    public required OperationStatus OperationStatus { get; init; }
    public string Reason { get; init; } = "";
    
    public DateTime TimeStamp { get; set; }
    public MetaDataSourceInfoModel? MetaDataSourceInfo { get; set; }
}