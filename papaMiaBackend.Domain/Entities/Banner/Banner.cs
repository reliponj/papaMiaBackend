using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace papaMiaBackend.Domain.Entities.Banner;

[Table("Banners")]
public class Banner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Link")]
    public string Link { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Sort")]
    public int Sort { get; set; } = 0;

}
