using JWTDemo.Model;
using JWTDemo.Request_Model;

namespace JWTDemo.Interface
{
    public interface IAuthService
    {
        User AddUser (User user);

        string Login(LoginRequest loginRequest);
    }
}
