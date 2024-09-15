using Fluent.Infrastructure.FluentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class PropertyRepository : IRepository<Property>
    {
        private readonly ApplicationDbContext _context;
        private ApplicationDbContext context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PropertyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _context.Properties.Include(p => p.User).ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task AddAsync(Property entity)
        {
            await _context.Properties.AddAsync(entity);
        }

        public async Task UpdateAsync(Property entity)
        {
            _context.Properties.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Properties.FindAsync(id);
            if (entity != null)
            {
                _context.Properties.Remove(entity);
            }
        }
    }

}
