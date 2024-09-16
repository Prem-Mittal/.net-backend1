using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class UpdateregionsRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be maximum of 3 characters")]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
