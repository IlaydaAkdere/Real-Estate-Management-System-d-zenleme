using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Property> Properties { get; }
        IRepository<User> Users { get; }
        Task<int> CompleteAsync();
    }

}
