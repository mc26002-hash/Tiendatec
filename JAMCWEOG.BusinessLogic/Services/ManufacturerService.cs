using JAMCWEOG.DataAccess.Repositories;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.BusinessLogic.Services
{
    public class ManufacturerService
    {
        private readonly ManufacturerRepository _manufacturerRepository;

        public ManufacturerService(ManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        // LISTAR
        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _manufacturerRepository.GetAllAsync();
        }

        // OBTENER POR ID
        public async Task<Manufacturer?> GetByIdAsync(int id)
        {
            return await _manufacturerRepository.GetByIdAsync(id);
        }

        // CREAR
        public async Task AddAsync(Manufacturer manufacturer)
        {
            await _manufacturerRepository.AddAsync(manufacturer);
        }

        // EDITAR
        public async Task UpdateAsync(Manufacturer manufacturer)
        {
            await _manufacturerRepository.UpdateAsync(manufacturer);
        }

        // ELIMINAR
        public async Task DeleteAsync(int id)
        {
            await _manufacturerRepository.DeleteAsync(id);
        }
    }
}