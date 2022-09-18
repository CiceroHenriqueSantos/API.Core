using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.CoreSystem.Manager.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var data = await personService.GetAllAsync();
            if (!data.Any())
                return NoContent();
            return Ok(data);
        }
    }
}
