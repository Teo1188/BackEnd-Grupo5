using ExtraHours.Core.Repositories;
using ExtraHours.Core.Services;
using ExtraHours.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace ExtraHours.Infrastructure.Services
{
    public class UserService : IUserService
    {
      private readonly IUserRepository _userRepository;
      private readonly PasswordHasher<User> _passwordHasher;
      private readonly IConfiguration _configuration;

      public UserService(IUserRepository userRepository, IConfiguration configuration)
      {
          _userRepository = userRepository;
          _passwordHasher = new PasswordHasher<User>();
          _configuration = configuration;
      }

      public async Task<IEnumerable<User>> GetUsers() => await _userRepository.GetAllUsersAsync();


      public async Task<string?> Authenticate(string email, string password)
      {
          var user = await _userRepository.GetByEmailAsync(email);
          if (user == null) return null;
          var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
          return result == PasswordVerificationResult.Success ? GenerateJwtToken(user): null;
      }

        public async Task<User> Register(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            await _userRepository.AddUserAsync(user);
            return user;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "secret_key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("role", user.RoleId.ToString())
    };

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}