using ExtraHours.Core.Models;

namespace ExtraHours.Core.Services

{
    public interface IUserService
    {
        Task<User?> Authenticate(string email, string password);
    }
}