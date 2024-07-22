using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behavior;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse> // IPipeline behavior interface
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.Where(v => v.Errors.Any()).SelectMany(v => v.Errors).ToList();

        if (failures.Any()) 
            throw new ValidationException(failures);

        return await next(); // calling the next method in order to continue this pipeline request lifecycle
        
    }
}
