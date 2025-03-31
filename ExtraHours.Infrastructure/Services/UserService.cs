using ExtraHours.Core.Repositories;
using ExtraHours.Core.Services;
using ExtraHours.Core.Models;

namespace ExtraHours.Infrastructure.Services
{
    public class UserService : IUserService
    {
      private readonly IUserRepository _userRepository;

      public UserService(IUserRepository userRepository)
      {
          _userRepository = userRepository;
      }

      public async Task<User?> Authenticate(string email, string password)
      {
          var user = await _userRepository.GetByEmailAsync(email);
          if (user == null || user.Password != password) return null;
          return user;
      }

    }
}