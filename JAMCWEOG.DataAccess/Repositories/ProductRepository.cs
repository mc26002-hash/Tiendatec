using JAMCWEOG.DataAccess.Context;
using JAMCWEOG.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace JAMCWEOG.DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Manufacturer)
                .ToListAsync();
        }

        // OBTENER POR ID
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _context.Products
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // CREAR
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // EDITAR
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        // ELIMINAR
        public async Task DeleteAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}