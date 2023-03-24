namespace Elevator.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("api/[controller]")]
public class ElevatorsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ElevatorModel>>> GetAllElevatorsAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ElevatorModel>> GetElevatorAsync(string id)
    {
        throw new NotImplementedException();
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