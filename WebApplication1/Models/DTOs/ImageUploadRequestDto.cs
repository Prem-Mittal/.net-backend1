using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; } //When a user uploads a file through a form and submits it,
                                            //ASP.NET Core automatically binds the uploaded file to this IFormFile property.
                                            //This process is known as model binding.
        [Required]
        public string Name { get; set; }

        public String? FileDescription { get; set; }
    }
}
