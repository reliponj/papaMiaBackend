using System.ComponentModel.DataAnnotations;

namespace papaMiaBackend.Domain.Models.Auth;

public class RefreshRequestDto
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}
