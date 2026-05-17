using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Review;

[Table("Reviews")]
public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string AuthorName { get; set; } = string.Empty;

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [StringLength(2000, MinimumLength = 1)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    public bool IsHidden { get; set; }
}
