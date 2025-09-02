using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationsServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticationsServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        private async Task<User?> ValidateUser(LoginRequest rq)
        {
            if (string.IsNullOrEmpty(rq.Email) || string.IsNullOrEmpty(rq.Password))
                return null;

            return await _userRepository.GetUser(rq.Email, rq.Password);
        }

        public async Task<string?> Login(LoginRequest rq)
        {
            var user = await ValidateUser(rq);
            if (user == null) return null;

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new("sub", user.Id.ToString()),
                new("role", user.Role)
            };

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest rq)
        {
            if (string.IsNullOrEmpty(rq.Email) || string.IsNullOrEmpty(rq.Password))
                return false;

            var existingUser = await _userRepository.GetUserByEmail(rq.Email);
            if (existingUser != null) return false;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(rq.Password);

            var user = new User
            {
                FirstName = rq.Firstname,
                LastName = rq.Lastname ?? "",
                Email = rq.Email,
                PasswordHash = hashedPassword,
                PhoneNumber = rq.PhoneNumber ?? "",
                Role = "Cliente",
                Orders = new List<Order>()
            };

            await _userRepository.CreateUser(user);
            return true;
        }

        public class AuthenticationsServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";

            public string? Issuer { get; set; }
            public string? Audience { get; set; }
            public string? SecretForKey { get; set; }
        }
    }
}
