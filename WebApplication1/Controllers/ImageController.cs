using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositiory;

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo img;

        public ImageController(IImageRepo img)
        {
            this.img = img;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult>Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            ValidateFileUpload(imageUploadRequestDto);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtension = Path.GetExtension(imageUploadRequestDto.File.FileName),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.Name,
                    FileDescription = imageUploadRequestDto.FileDescription
                };
                await img.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);

        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequest) 
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtension.Contains(Path.GetExtension(imageUploadRequest.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported FileExtension");
            }
            if (imageUploadRequest.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is more");
            }
        }
    }
}
