using api_db_first.Models;

namespace api_db_first.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
