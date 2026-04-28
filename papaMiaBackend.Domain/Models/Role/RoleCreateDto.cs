namespace papaMiaBackend.Domain.Models.Role;

public class RoleCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsSystem { get; set; } = true;
    public List<int> PermissionIds { get; set; } = new();
}
