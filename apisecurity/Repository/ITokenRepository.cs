using apisecurity.Models;

namespace apisecurity.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Users users);
    }
}
