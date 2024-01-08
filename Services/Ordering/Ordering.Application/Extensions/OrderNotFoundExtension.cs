namespace Ordering.Application.Extensions;

public class OrderNotFoundExtension(string name, object key)
    : ApplicationException($"Entity {name} - {key} was not found.");