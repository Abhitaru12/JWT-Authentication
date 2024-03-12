using JWTDemo.Context;
using JWTDemo.Interface;
using JWTDemo.Model;
using JWTDemo.Request_Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Services
{
    public class AuthService : IAuthService
    {
        private readonly JWTContext _jwtService;
        private readonly IConfiguration _configuration;
        public AuthService(JWTContext jwtContext, IConfiguration configuration)
        {
            _jwtService = jwtContext;
            _configuration = configuration;
        }
        public User AddUser(User user)
        {
            var addedUser = _jwtService.Add(user);
            _jwtService.SaveChanges();
            return addedUser.Entity;

        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.userName != null && loginRequest.password != null)
            {
                var user = _jwtService.Users.SingleOrDefault(s => s.Email == loginRequest.userName && s.Password == loginRequest.password);
                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("user is not valid");
                }
            }
            else
            {
                throw new Exception("credentials are not valid");
            }
        }
    }
}
