namespace e_commerce_server
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        //mapper

        public ProductService(
            IProductRepository productRepository
            // mapper
        )
        {
            _productRepository = productRepository;
            //mapper
        }
        public async Task<IList<Product>> GetAllAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product> GetAsync(Guid id) =>
            await _productRepository.GetAsync(id);

        public async Task DeleteAsync(Guid id) =>
             await _productRepository.DeleteAsync(id);

        public async Task UpdateAsync(Guid id, Product item) =>
            await _productRepository.UpdateAsync(id, item);

        public async Task CreateAsync(Product item) =>
            await _productRepository.CreateAsync(item);
    }
}
