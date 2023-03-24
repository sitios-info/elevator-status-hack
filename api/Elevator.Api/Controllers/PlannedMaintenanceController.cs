using Elevator.Api.Migrations;
using Elevator.Api.Model;
using Elevator.Domain;
using Elevator.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elevator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlannedMaintenanceController: ControllerBase
{
    private readonly AppDbContext _ctx;

    public PlannedMaintenanceController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlannedMaintenanceModel>>> PlannedMaintenances([FromQuery] Guid? elevatorId)
    {
        var plannedMaintenances = await _ctx.PlannedMaintenances.Where(pm => pm.Elevator.Id == elevatorId)
            .Select(m => m.ToModel())
            .ToListAsync();
        return Ok(plannedMaintenances);
    }
    
    [HttpPost]
    public async Task<ActionResult<PlannedMaintenanceModel>> PlannedMaintenances(CreatePlannedMaintenanceModel createPlannedMaintenanceModel)
    {
        var elevator = await _ctx.Elevators.FindAsync(createPlannedMaintenanceModel.ElevatorId);

        if (elevator is null)
        {
            return NotFound();
        }

        var plannedMaintenance = new PlannedMaintenance
        {
            Elevator = elevator,
            Description = createPlannedMaintenanceModel.Description,
            End = createPlannedMaintenanceModel.End,
            Start = createPlannedMaintenanceModel.Start,
            Reason = createPlannedMaintenanceModel.Reason,
            ExpectedOperationStatus = createPlannedMaintenanceModel.ExpectedOperationStatus ?? "NotOperational"
        };

        _ctx.PlannedMaintenances.Add(plannedMaintenance);
        await _ctx.SaveChangesAsync();
        
        return Ok(plannedMaintenance.ToModel());
    }
}