using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Repositiory
{
    public interface ITokenRepo
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
