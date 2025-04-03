using ExtraHours.Core.Models;
using ExtraHours.Core.Repositories;
using ExtraHours.Core.Services;

namespace ExtraHours.Infrastructure.Services
{
    public class ExtraHourTypeService : IExtraHourTypeService
    {
        private readonly IExtraHourTypeRepository _extraHourTypeRepository;

        public ExtraHourTypeService(IExtraHourTypeRepository extraHourTypeRepository)
        {
            _extraHourTypeRepository = extraHourTypeRepository;
        }

        public async Task<IEnumerable<ExtraHourType>> GetAllTypes()
        {
            return await _extraHourTypeRepository.GetAllAsync();
        }

        public async Task<ExtraHourType?> GetTypeById(int id)
        {
            return await _extraHourTypeRepository.GetByIdAsync(id);
        }

        public async Task<ExtraHourType> CreateType(ExtraHourType extraHourType)
        {
            await _extraHourTypeRepository.AddAsync(extraHourType);
            return extraHourType;
        }

        public async Task<ExtraHourType?> UpdateType(int id, ExtraHourType updatedType)
        {
            var existingType = await _extraHourTypeRepository.GetByIdAsync(id);
            if (existingType == null) return null;

            existingType.Name = updatedType.Name;
            existingType.RateMultiplier = updatedType.RateMultiplier;
            
            await _extraHourTypeRepository.UpdateAsync(existingType);
            return existingType;
        }

        public async Task<bool> DeleteType(int id)
        {
            var existingType = await _extraHourTypeRepository.GetByIdAsync(id);
            if (existingType == null) return false;

            await _extraHourTypeRepository.DeleteAsync(id);
            return true;
        }
    }
}