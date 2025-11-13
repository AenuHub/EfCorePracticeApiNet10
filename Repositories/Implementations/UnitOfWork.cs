using EfCorePracticeApiNet10.Data;
using EfCorePracticeApiNet10.Models;
using EfCorePracticeApiNet10.Repositories.Interfaces;

namespace EfCorePracticeApiNet10.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Product> Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new GenericRepository<Product>(_context);
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
