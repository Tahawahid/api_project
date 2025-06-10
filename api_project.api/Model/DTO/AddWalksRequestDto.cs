using System.ComponentModel.DataAnnotations;

namespace api_project.api.Model.DTO
{
    public class AddWalksRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum 3 Characters Required!")]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(256, ErrorMessage = "Maximum 256 Characters Allowed!")]
        public string Description { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Length must be between 0 and 10 kilometers.")]
        public double LengthInKM { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }


    }
}
