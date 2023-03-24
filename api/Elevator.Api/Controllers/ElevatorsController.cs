using Microsoft.EntityFrameworkCore;

namespace Elevator.Api.Controllers;

using Domain;
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
        return Ok(_dbContext.Elevators.AsEnumerable().Select(e => e.ToModel()));
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

    [HttpPut]
    public async Task<ActionResult<ElevatorModel>> PutElevatorAsync()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ElevatorModel>> DeleteElevatorAsync(string id)
    {
        throw new NotImplementedException();
    }
}