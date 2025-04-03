using ExtraHours.Core.Models;
using ExtraHours.Core.Repositories;
using ExtraHours.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExtraHours.Infrastructure.Repositories
{
    public class ExtraHourTypeRepository : IExtraHourTypeRepository
    {
        private readonly AppDbContext _context;

        public ExtraHourTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExtraHourType>> GetAllAsync() => 
            await _context.ExtraHourTypes.ToListAsync();

        public async Task<ExtraHourType?> GetByIdAsync(int id) => 
            await _context.ExtraHourTypes.FindAsync(id);

        public async Task<ExtraHourType?> GetByNameAsync(string name) => 
            await _context.ExtraHourTypes.FirstOrDefaultAsync(x => x.Name == name);

        public async Task AddAsync(ExtraHourType extraHourType)
        {
            _context.ExtraHourTypes.Add(extraHourType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExtraHourType extraHourType)
        {
            extraHourType.UpdatedAt = DateTime.UtcNow;
            _context.ExtraHourTypes.Update(extraHourType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var extraHourType = await _context.ExtraHourTypes.FindAsync(id);
            if (extraHourType != null)
            {
                _context.ExtraHourTypes.Remove(extraHourType);
                await _context.SaveChangesAsync();
            }
        }
    }
}