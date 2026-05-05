namespace papaMiaBackend.Domain.Models.Role;

public class PermissionGroupUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<int> PermissionIds { get; set; } = new();
}
