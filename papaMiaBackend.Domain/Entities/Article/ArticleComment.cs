using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Article;

[Table("ArticleComments")]
public class ArticleComment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int ArticleId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(2000)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(ArticleId))]
    public Article Article { get; set; } = null!;
}
