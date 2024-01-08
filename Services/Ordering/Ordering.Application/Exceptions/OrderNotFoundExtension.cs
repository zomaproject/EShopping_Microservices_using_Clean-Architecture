namespace Ordering.Application.Exceptions;

public class OrderNotFoundExtension(string name, object key)
    : ApplicationException($"Entity {name} - {key} was not found.");