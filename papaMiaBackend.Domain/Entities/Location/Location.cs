using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace papaMiaBackend.Domain.Entities.Location;

[Table("Locations")]
public class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name cannot be longer than 50 chars.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Address")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Address cannot be longer than 100 chars.")]
    public string Address { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Phone number")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Phone number cannot be longer than 20 chars.")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Worktime")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Worktime cannot be longer than 100 chars.")]
    public string Worktime { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Latitude")]
    public double Latitude { get; set; }

    [Required]
    [Display(Name = "Longitude")]
    public double Longitude { get; set; }

    [Display(Name = "ImageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

}