using API.CoreSystem.Manager.Domain.API;
using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;
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
        private readonly INotificationService notificationService;

        public PersonController(IPersonService personService, INotificationService notificationService)
        {
            this.personService = personService;
            this.notificationService = notificationService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Person>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<PagedResult<Person>>> GetAll(int page, int pageSize)
        {
            var data = await personService.GetAllPersons(page, pageSize);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var data = await personService.GetAsync(id);
            if (data != null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<Person>> Add(AddPerson dto)
        {
            var data = await personService.AddAsync(dto);
            if (notificationService.HasErrors)
                return BadRequest(notificationService.Notification.Errors);
            return Ok(data);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<Person>> Update(UpPerson dto)
        {
            await personService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await personService.DeleteAsync(id);
            return Ok();
        }
    }
}
