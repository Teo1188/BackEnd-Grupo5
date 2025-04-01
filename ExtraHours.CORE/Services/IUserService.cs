using ExtraHours.Core.Models;

namespace ExtraHours.Core.Services

{
    public interface IUserService
    {
        Task<string?> Authenticate(string email, string password);
        Task<User> Register(User user);
        Task<IEnumerable<User>> GetUsers();
    }
}