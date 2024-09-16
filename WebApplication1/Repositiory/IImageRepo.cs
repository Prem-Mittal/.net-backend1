

using WebApplication1.Models.Domain;

namespace WebApplication1.Repositiory
{
    public interface IImageRepo
    {
        Task<Image> Upload (Image image);       //Task: Represents an asynchronous operation
    }
}
