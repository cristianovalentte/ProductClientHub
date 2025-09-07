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

            if (result.IsValid == false)
            {
                throw new ArgumentException("ERRO NOS DADOS RECEBIDOS");
            }

            return new ResponseClientJson();
        }
    }
}
