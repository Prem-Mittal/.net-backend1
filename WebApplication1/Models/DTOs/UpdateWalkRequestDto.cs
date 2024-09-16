using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class UpdateWalkRequestDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageurl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
