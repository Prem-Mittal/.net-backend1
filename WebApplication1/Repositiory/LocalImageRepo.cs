using System.Net.Mime;
using WebApplication1.Data;
using WebApplication1.Models.Domain;

namespace WebApplication1.Repositiory
{
    public class LocalImageRepo : IImageRepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;    //Provides information about the web hosting environment, including the content root path where files can be saved.
        private readonly IHttpContextAccessor httpContextAccessor;  //Provides access to the current HTTP context, which is used to construct the URL for the uploaded image.
        private readonly oneDbContext dbcontext;

        public LocalImageRepo(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, oneDbContext dbcontext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbcontext = dbcontext;
        }

        public async Task<Image> Upload(Image image)
        {
            //localFilePth Represents the location of a file on the server’s filesystem where the file is physically stored.
            var localFilePth = Path.Combine(webHostEnvironment.ContentRootPath,"Images",$"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localFilePth, FileMode.Create);   //FileStream: Creates or opens a file at the specified path (localFilePth) with the FileMode.Create option, which creates a new file or overwrites an existing file.
            await image.File.CopyToAsync(stream);   //image.File.CopyToAsync(stream): Asynchronously copies the contents of the uploaded file to the FileStream.
            //urlFilePath Represents the URL that clients (such as web browsers) use to access the file over HTTP or HTTPS.
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme};//{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await dbcontext.Images.AddAsync(image);
            await dbcontext.SaveChangesAsync();
            return image;

        }
    }
}
