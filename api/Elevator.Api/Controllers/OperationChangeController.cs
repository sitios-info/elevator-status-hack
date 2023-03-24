using Elevator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationChangeController: Controller
{
    private readonly AppDbContext _ctx;

    public OperationChangeController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        throw new NotImplementedException();
    }
}