using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Promocode;

[Table("Promocodes")]
public class Promocode
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Code")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Percent")]
    public int Percent { get; set; } = 0;

    [Required]
    [Display(Name = "ExpiryDate")]
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(30);

    [Required]
    [Display(Name = "IsActive")]
    public bool IsActive { get; set; } = true;
}