using Fluent.Infrastructure.FluentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Property> Properties { get; private set; }
        public IRepository<User> Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Properties = new PropertyRepository(_context);
            Users = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
