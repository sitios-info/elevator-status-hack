namespace Elevator.Api.Controllers;

using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

[ApiController]
[Route("api/[controller]")]
public class OperatorsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public OperatorsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperatorModel>>> GetAllOperatorsAsync()
    {
        return Ok(await _dbContext.Operators.ToArrayAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<OperatorModel>>> GetOperatorAsync(Guid id)
    {
        var @operator = await _dbContext.Operators.FindAsync(id);

        return @operator != null
            ? Ok(@operator)
            : NotFound();
    }

    [HttpGet("{id}/elevators")]
    public async Task<ActionResult<IEnumerable<ElevatorModel>>> GetAllElevatorsAsync(Guid id)
    {
        var @operator = await _dbContext.Operators.FindAsync(id);
        if (@operator == null)
            return NotFound();

        var elevators = await _dbContext.Elevators
            .Where(e => e.Operator == @operator)
            .Include(e => e.Events)
            .ToArrayAsync();

        return Ok(elevators.Select(e => e.ToModel()));
    }
}