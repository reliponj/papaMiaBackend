using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.Domain.Entities.Role;

[Table("Roles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Code { get; set; } = string.Empty;

    [StringLength(250)]
    public string Description { get; set; } = string.Empty;

    public bool IsSystem { get; set; } = true;

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
