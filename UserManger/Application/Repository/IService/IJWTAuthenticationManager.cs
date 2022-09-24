using System.Security.Claims;
using Domain.Entity;

namespace User_management.Repository
{
    public interface IJWTAuthenticationManager
    {
        public Token Authenticate(User usr);

        public string GenerateRefreshToken();

    }
}
