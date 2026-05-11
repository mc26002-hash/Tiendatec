using JAMCWEOG.DataAccess.Repositories;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.BusinessLogic.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // LISTAR
        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // OBTENER POR ID
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // CREAR
        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        // EDITAR
        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        // ELIMINAR
        public async Task DeleteAsync(long id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}