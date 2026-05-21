using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IngNs = papaMiaBackend.Domain.Entities.Ingridient;

namespace papaMiaBackend.Domain.Entities.CustomPizza;

[Table("CustomPizzas")]
public class CustomPizza
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int TotalPrice { get; set; }

    public ICollection<IngNs.Ingridient> Ingridients { get; set; } = new List<IngNs.Ingridient>();
}
