using API_Farm.Data;
using API_Farm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Farm.Controllers.v1.AnimalTypes;

[ApiController]
[Route("api/v1/[controller]")]
public class AnimalTypesController : ControllerBase
{
    private readonly AppDbContext Context;

    public AnimalTypesController(AppDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all animal types",
        Description = "Returns all available animal types."
    )]
    [SwaggerResponse(200, "Returns a list of animal types.", typeof(IEnumerable<AnimalType>))]
    [SwaggerResponse(204, "There are no registered animal types.")]
    [SwaggerResponse(500, "An internal server error occurred.")]
    public async Task<IActionResult> GetAll() {
        var animalTypes = await Context.AnimalTypes.ToListAsync();
        if (animalTypes.Any() == false)
        {
            return NoContent();
        } else
        {
            return Ok(animalTypes);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AnimalType animalType) 
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        Context.AnimalTypes.Add(animalType);
        await Context.SaveChangesAsync();
        return Ok("created");
    }
}
