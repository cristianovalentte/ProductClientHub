using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;
using ProductClientHub.Exceptions.ExcpetionsBase;

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
            catch (ProductClientHubException ex)
            { 
                //Lógica para gravar os erros em um log (arquivo, banco de dados, etc)
                var errors = ex.GetErrors();

                //BadRequest = 400 => Client Error
                return BadRequest(new ResponseErrorMessageJson(errors));
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
