using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Article;

[Table("Articles")]
public class Article
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    [Required]
    [Display(Name = "ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;
}
