using System.ComponentModel.DataAnnotations;

namespace DesignPatternsASP.Models.ViewModels
{
    public class FormBeerViewModel
    {
        [Required]
        [Display (Name="Name") ]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Style")]
        public string Style { get; set; }

        [Display (Name="Brand") ]
        public Guid? BrandId { get; set; }
        [Display(Name = "Brand")]
        public string? OtherBrand { get; set; }
    }
}
