namespace Ordering.Core.Common;

public class EntityBase
{
    // Protected set is used to allow the entity to be set by the ORM 

    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }
}