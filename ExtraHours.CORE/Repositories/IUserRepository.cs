using ExtraHours.Core.Models;

namespace ExtraHours.Core.Repositories{

    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}