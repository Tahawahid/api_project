using System.ComponentModel.DataAnnotations;

namespace api_project.api.Model.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "Minimum 3 Charecter Required!")]
        [MaxLength(5, ErrorMessage = "Maximum 5 Charecter Allowed!")]
        public string Code { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximum 50 Charecter Allowed!")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
