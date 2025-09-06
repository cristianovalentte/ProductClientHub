using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientsUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            return new ResponseClientJson();
        }
    }
}
