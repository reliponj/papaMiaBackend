namespace papaMiaBackend.Domain.Models.Category;
public class CategoryUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Sort { get; set; } = 0;
}
