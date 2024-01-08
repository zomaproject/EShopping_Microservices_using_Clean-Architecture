using FluentValidation.Results;

namespace Ordering.Application.Exceptions;

public class ValidatorException() : ApplicationException("One or more validation failures have occurred.")
{
    public ValidatorException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}