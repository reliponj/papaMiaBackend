using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace papaMiaBackend.Domain.Entities.Product;

[Table("Products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name cannot be longer than 50 chars.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Price")]
    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public int Price { get; set; } = 0;

    [Required]
    [Display(Name = "ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [Display(Name = "Allergens")]
    public string Allergens { get; set; } = string.Empty;

    [Display(Name = "IsActive")]
    public bool IsActive { get; set; } = true;
}

