namespace Application.Functions.Categories.Queries.GetCategoryListWithPosts;

public class CategoryPostListViewModel
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public ICollection<CategoryPostDto>? Posts { get; set; }
}
