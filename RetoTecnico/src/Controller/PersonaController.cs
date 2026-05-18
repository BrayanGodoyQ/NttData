using Microsoft.AspNetCore.Mvc;
using RetoTecnico.src.Services.Interfaces;
using RetoTecnico.src.Models;

namespace TestNttData.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonaResponse>))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetPersonas()
        {
            var personasResponse = await _personaService.ObtenerDiezPersonasAsync();
            return Ok(personasResponse);
        }
    }
}