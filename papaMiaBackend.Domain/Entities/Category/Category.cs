using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using papaMiaBackend.Domain.Entities.Product;

namespace papaMiaBackend.Domain.Entities.Category;

[Table("Categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name cannot be longer than 50 chars.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Icon")]
    public string Icon { get; set; } = string.Empty;

    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Sort")]
    [Range(0, int.MaxValue, ErrorMessage = "Sort must be a positive number.")]
    public int Sort { get; set; }

    public ICollection<Product.Product> Products { get; set; } = new List<Product.Product>();
}
