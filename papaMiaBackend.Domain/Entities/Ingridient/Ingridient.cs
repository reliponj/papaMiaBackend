using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;

namespace papaMiaBackend.Domain.Entities.Ingridient;

public enum IngridientType
{
    Dough = 0,
    Sauce = 1,
    Extra = 2
}

[Table("Ingridients")]
public class Ingridient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public IngridientType Type { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public ICollection<PizzaNs.CustomPizza> CustomPizzas { get; set; } = new List<PizzaNs.CustomPizza>();
}
