using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace papaMiaBackend.Domain.Entities.Cart;

[Table("CartItems")]
public class CartItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int CartId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; } = 1;

    public Cart Cart { get; set; } = null!;
}
