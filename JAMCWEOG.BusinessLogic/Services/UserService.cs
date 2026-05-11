using JAMCWEOG.DataAccess.Repositories;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.BusinessLogic.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // LISTAR
        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // OBTENER POR ID
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // CREAR
        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        // EDITAR
        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        // ELIMINAR
        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}