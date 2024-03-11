using FluentValidation;
using MediatR;

namespace CQRSWithMediatR.Application.Features.Validaton;
public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    // Definida a lista de validatores que serão usados para validar objeto do TRequest
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Verifica se há validadores definidos
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            // Executa todas as validações de forma assíncrona
            var validationResults = await Task.WhenAll(_validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

            // Armazena possíveis erros
            var failures = validationResults.SelectMany(r => r.Errors)
                .Where(f => f != null).ToList();

            // Se houver falhar é soltando uma exceção FluentValidation.ValidationException
            if (failures.Count != 0)
                throw new FluentValidation.ValidationException(failures);
        }

        return await next();
    }
}
