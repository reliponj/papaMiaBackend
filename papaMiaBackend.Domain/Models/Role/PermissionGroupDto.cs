namespace papaMiaBackend.Domain.Models.Role;

public class PermissionGroupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<PermissionDto> Permissions { get; set; } = new();
}
