using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CQRSWithMediatR.API.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    // Acesso ao contexto da request
    public void OnException(ExceptionContext context)
    {
        // Se for uma execeção lançada pelo FluentValidation
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(err => $"{err.PropertyName}: {err.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { Errors = errors })
            {
                StatusCode = 400,
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
        else if (context.Exception is ArgumentNullException || context.Exception is KeyNotFoundException)
        {
            // Tratar erro 404
            context.Result = new NotFoundObjectResult(new { Error = "Resource not found" });
            context.ExceptionHandled = true;
        } else if (context.Exception is HttpRequestException || context.Exception is InvalidOperationException)
        {
            // Tratar erro 500
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            context.ExceptionHandled = true;
        }
    }
}
