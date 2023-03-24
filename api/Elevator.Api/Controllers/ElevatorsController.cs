using Microsoft.EntityFrameworkCore;

namespace Elevator.Api.Controllers;

using Domain;
using Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("api/[controller]")]
public class ElevatorsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ElevatorsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Gets all elevators.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ElevatorModel>>> GetAllElevatorsAsync()
    {
        return Ok(_dbContext.Elevators.Include(e => e.Events).AsEnumerable().Select(e => e.ToModel()));
    }

    /// <summary>
    /// Gets a certain elevator by id
    /// </summary>
    /// <param name="id">The id of the elevator which should be returned.</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ElevatorModel>> GetElevatorAsync(Guid id)
    {
        var elevator = await _dbContext.Elevators
            .Include(e => e.MetaDataSourceInfo)
            .Include(e => e.Events)
            .Where(e => e.Id == id)
            .SingleOrDefaultAsync();
        return elevator != null
            ? Ok(elevator.ToModel())
            : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ElevatorModel>> PostElevatorAsync([FromBody] ElevatorCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var elevator = new Elevator
        {
            Location = null,
            ManufacturerName = model.ManufacturerName,
            OpenStreetMapId = model.OpenStreetMapId,
            Operator = null,
            Properties = model.Properties ?? new Dictionary<string, string>(),
            SerialNumber = model.SerialNumber,
            Events = ArraySegment<OperationChangeEvent>.Empty
        };

        await _dbContext.Elevators.AddAsync(elevator);
        await _dbContext.SaveChangesAsync();

        return Ok(elevator.ToModel());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteElevatorAsync(Guid id)
    {
        var elevator = await _dbContext.Elevators.FindAsync(id);
        if (elevator != null)
        {
            _dbContext.Elevators.Remove(elevator);
            await _dbContext.SaveChangesAsync();
        }

        return Ok();
    }
}