namespace papaMiaBackend.Domain.Models.Role;

public class RoleUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsSystem { get; set; }
    public List<int> PermissionIds { get; set; } = new();
}
