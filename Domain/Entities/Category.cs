using Domain.Common;

namespace Domain.Entities;

public class Category : AuditableEntity
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public ICollection<Post>? Posts { get; set; }
}
