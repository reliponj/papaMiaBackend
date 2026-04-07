
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.User;

[Table("Users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Username")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 chars.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Password")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 chars.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Email")]
    [StringLength(30)]
    public string Email { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime LastLogin { get; set; }

    [StringLength(30)]
    public string LastIp { get; set; } = string.Empty;

    public URole Level { get; set; }
}
