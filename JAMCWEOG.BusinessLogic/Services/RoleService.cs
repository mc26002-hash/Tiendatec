using JAMCWEOG.DataAccess.Repositories;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.BusinessLogic.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // LISTAR
        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        // OBTENER POR ID
        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        // CREAR
        public async Task AddAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
        }

        // EDITAR
        public async Task UpdateAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        // ELIMINAR
        public async Task DeleteAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
    }
}