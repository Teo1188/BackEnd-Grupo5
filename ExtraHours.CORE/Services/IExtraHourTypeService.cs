using ExtraHours.Core.Models;

namespace ExtraHours.Core.Services
{
    public interface IExtraHourTypeService
    {
        Task<IEnumerable<ExtraHourType>> GetAllTypes();
        Task<ExtraHourType?> GetTypeById(int id);
        Task<ExtraHourType> CreateType(ExtraHourType extraHourType);
        Task<ExtraHourType?> UpdateType(int id, ExtraHourType updatedType);
        Task<bool> DeleteType(int id);
    }
}