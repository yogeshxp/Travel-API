using Microsoft.AspNetCore.Identity;

namespace Travel_API.UsersRepositories.Token
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, IList<string> roles);
    }
}
