using EfCorePracticeApiNet10.Models;

namespace EfCorePracticeApiNet10.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Products { get; }
        Task<int> CompleteAsync();
    }
}
