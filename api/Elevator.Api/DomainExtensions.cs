namespace Elevator.Api;

using Domain.Data;
using Model;

public static class DomainExtensions
{
    public static ElevatorModel ToModel(this Elevator elevator)
    {
        var lastEvent = elevator.Events?.OrderBy(e => e.ChangedTime).LastOrDefault();


        return new ElevatorModel
        {
            Id = elevator.Id,
            Location = elevator.Location.ToModel(),
            ManufacturerName = elevator.ManufacturerName,
            SerialNumber = elevator.SerialNumber,
            OpenStreetMapId = elevator.OpenStreetMapId,
            Properties = elevator.Properties,
            Operator = elevator.Operator.ToModel(),
            IsOperational = (lastEvent is null) || string.Equals(lastEvent.OperationMode, "Operational", StringComparison.InvariantCultureIgnoreCase)
        };
    }

    public static GeoLocationModel? ToModel(this GeoLocation? location)
    {
        if (location == null)
            return null;

        return new GeoLocationModel
        {
            Id = location.Id,
            AddressText = location.AddressText,
            Geometry = CreateGeometry(location.Latitude, location.Longitude),
            OpenStreetMaPlaceId = location.OpenStreetMaPlaceId
        };
    }

    public static OperatorModel? ToModel(this Operator? @operator)
    {
        if (@operator == null)
            return null;
        
        return new OperatorModel
        {
            Id = @operator.Id,
            Name = @operator.Name,
            ContactEmail = @operator.ContactEmail,
            ContactPhone = @operator.ContactPhone
        };
    }

    public static MetaDataSourceInfoModel? ToModel(this MetaDataSourceInfo? metaDataSourceInfo)
    {
        return metaDataSourceInfo is not null
            ? new MetaDataSourceInfoModel
            {
                TimeStamp = metaDataSourceInfo.TimeStamp,
                License = metaDataSourceInfo.License,
                SourceType = metaDataSourceInfo.SourceType,
            }
            : null;
    }
    
    public static OperationChangeModel ToModel(this OperationChangeEvent operationChangeEvent)
    {
        return new OperationChangeModel
        {
            OperationStatus = Enum.Parse<OperationStatus>(operationChangeEvent.OperationMode),
            Reason = operationChangeEvent.Reason,
            TimeStamp = operationChangeEvent.ChangedTime,
            MetaDataSourceInfo = operationChangeEvent.MetaDataSourceInfo.ToModel(),
        };
    }

    private static GeometryModel CreateGeometry(double latitude, double longitude)
    {
        return new GeometryModel
        {
            Type = "Point",
            Coordinates = new[] { latitude, longitude }
        };
    }

    public static PlannedMaintenanceModel ToModel(this PlannedMaintenance maintenance)
    {
        return new PlannedMaintenanceModel
        {
            Id = maintenance.Id,
            Reason = maintenance.Reason,
            Description = maintenance.Description,
            End = maintenance.End,
            Start = maintenance.Start,
        };
    }
}