using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientsUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                //BadRequest = 400 => Client Error
                return BadRequest(new ResponseErrorMessageJson(ex.Message));
            }
            catch 
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new ResponseErrorMessageJson("ERRO DESCONHECIDO."));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
