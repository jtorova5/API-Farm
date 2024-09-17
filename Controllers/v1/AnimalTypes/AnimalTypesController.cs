using API_Farm.Data;
using Microsoft.AspNetCore.Mvc;

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
}
