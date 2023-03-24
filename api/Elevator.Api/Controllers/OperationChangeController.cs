using Elevator.Api.Model;
using Elevator.Domain;
using Elevator.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elevator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationChangeController : Controller
{
    private readonly AppDbContext _ctx;

    public OperationChangeController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] Guid elevatorId,
        [FromBody] OperationChangeModel operationChangeModel)
    {
        var elevator = await _ctx.Elevators.FindAsync(elevatorId);

        if (elevator is null)
            return NotFound($"Elevator with id '{elevatorId}' does not exist.");


        MetaDataSourceInfo? metaData = null;
        if (operationChangeModel.MetaDataSourceInfo is not null)
        {
            metaData = new MetaDataSourceInfo
            {
                License = operationChangeModel.MetaDataSourceInfo.License,
                TimeStamp = operationChangeModel.MetaDataSourceInfo.TimeStamp,
                SourceType = operationChangeModel.MetaDataSourceInfo.SourceType,
            };
        }

        var operationChangeEvent = new OperationChangeEvent
        {
            ChangedTime = DateTime.UtcNow,
            Elevator = elevator,
            OperationMode = operationChangeModel.OperationStatus.ToString(),
            Reason = operationChangeModel.Reason,
            MetaDataSourceInfo = metaData
        };

        _ctx.OperationChangedEvents.Add(operationChangeEvent);
        await _ctx.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetOperationChanges([FromQuery] Guid? elevatorId)
    {
        var changes = await _ctx.OperationChangedEvents
            .Where(op => op.Elevator.Id == elevatorId)
            .ToListAsync();

        return Ok(changes.Select(o => o.ToModel()));
    }
}