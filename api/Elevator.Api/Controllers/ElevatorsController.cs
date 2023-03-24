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

        var elevator = await CreateElevatorAsync(model);

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

    private async Task<Elevator> CreateElevatorAsync(ElevatorCreateModel model)
    {
        return new Elevator
        {
            Location = new GeoLocation
            {
                AddressText = model.Location.AddressText,
                Latitude = model.Location.Geometry.Coordinates[0],
                Longitude = model.Location.Geometry.Coordinates[1],
                OpenStreetMaPlaceId = model.Location.OpenStreetMaPlaceId
            },
            ManufacturerName = model.ManufacturerName,
            OpenStreetMapId = model.OpenStreetMapId,
            Operator = await GetOrCreateOperatorAsync(model.Operator),
            Properties = model.Properties ?? new Dictionary<string, string>(),
            SerialNumber = model.SerialNumber,
            Events = ArraySegment<OperationChangeEvent>.Empty
        };
    }

    private async Task<Operator> GetOrCreateOperatorAsync(OperatorCreateModel model)
    {
        var @operator = await _dbContext.Operators.FirstOrDefaultAsync(e => e.Name == model.Name);
        if (@operator != null)
            return @operator;

        return new Operator
        {
            Name = model.Name,
            ContactEmail = model.ContactEmail ?? "",
            ContactPhone = model.ContactPhone ?? ""
        };
    }
}