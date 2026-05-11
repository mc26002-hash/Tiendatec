using JAMCWEOG.DataAccess.Context;
using JAMCWEOG.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace JAMCWEOG.DataAccess.Repositories
{
    public class ManufacturerRepository
    {
        private readonly ApplicationDbContext _context;

        public ManufacturerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        // OBTENER POR ID
        public async Task<Manufacturer?> GetByIdAsync(int id)
        {
            return await _context.Manufacturers.FindAsync(id);
        }

        // CREAR
        public async Task AddAsync(Manufacturer manufacturer)
        {
            await _context.Manufacturers.AddAsync(manufacturer);
            await _context.SaveChangesAsync();
        }

        // EDITAR
        public async Task UpdateAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(manufacturer);
            await _context.SaveChangesAsync();
        }

        // ELIMINAR
        public async Task DeleteAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
        }
    }
}