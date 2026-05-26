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
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    [Required]
    [Display(Name = "ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<ArticleComment> Comments { get; set; } = new List<ArticleComment>();
}
