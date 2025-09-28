﻿using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;
using ProductClientHub.Exceptions.ExcpetionsBase;

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
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}
