using FluentValidation;
using MediatR;

namespace Doctors.Application.Commands
{
    public class ValidationHandler<TRequest, Unit> : IPipelineBehavior<TRequest, Unit> where TRequest : IRequest<Unit>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationHandler(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<Unit> Handle(TRequest request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var error = string.Join("\r\n", failures);;
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}