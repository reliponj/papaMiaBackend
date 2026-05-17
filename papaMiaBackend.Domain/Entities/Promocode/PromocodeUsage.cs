using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Promocode;

[Table("PromocodeUsages")]
public class PromocodeUsage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int PromocodeId { get; set; }

    [Required]
    public DateTime UsedAt { get; set; }

    public Promocode Promocode { get; set; } = null!;
}
