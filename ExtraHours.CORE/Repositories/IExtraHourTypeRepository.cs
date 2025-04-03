using ExtraHours.Core.Models;

namespace ExtraHours.Core.Repositories
{
    public interface IExtraHourTypeRepository
    {
        Task<IEnumerable<ExtraHourType>> GetAllAsync();
        Task<ExtraHourType?> GetByIdAsync(int id);
        Task<ExtraHourType?> GetByNameAsync(string name);
        Task AddAsync(ExtraHourType extraHourType);
        Task UpdateAsync(ExtraHourType extraHourType);
        Task DeleteAsync(int id);
    }
}