using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.Domain.Models.User;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; }
    public string LastIp { get; set; } = string.Empty;
}
