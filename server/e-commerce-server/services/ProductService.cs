using System;
using System.Collections.Generic;
using System.Linq;

namespace e_commerce_server
{
    public class ProductService : IProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 0,
                    CardPrice = 44.50,
                    CommonPrice = 50.50,
                    Title = "Г/Ц Блинчики с мясом",
                    Rating = 3,
                    Image = "assets/common/test.jpg",
                    Country = "Россия",
                    Weight = 180,
                    Article = 371431,
                    Reviews=  3,
                    Brand = "Мясное хозяйство"

                },
                new Product
                {
                    Id = 1,
                    CardPrice = 44.50,
                    CommonPrice = 50.50,
                    Title = "Г/Ц Блинчики с мясом",
                    Rating = 3,
                    Image = "assets/common/test.jpg",
                    Country = "Россия",
                    Weight = 180,
                    Article = 371431,
                    Reviews=  3,
                    Brand = "Мясное хозяйство"

                },
                new Product
                {
                    Id = 2,
                    CardPrice = 44.50,
                    CommonPrice = 50.50,
                    Title = "Г/Ц Блинчики с мясом",
                    Rating = 3,
                    Image = "assets/common/test.jpg",
                    Country = "Россия",
                    Weight = 180,
                    Article = 371431,
                    Reviews=  3,
                    Brand = "Мясное хозяйство"

                },
                new Product
                {
                    Id = 3,
                    CardPrice = 44.50,
                    CommonPrice = 50.50,
                    Title = "Г/Ц Блинчики с мясом",
                    Rating = 3,
                    Image = "assets/common/test.jpg",
                    Country = "Россия",
                    Weight = 180,
                    Article = 371431,
                    Reviews=  3,
                    Brand = "Мясное хозяйство"

                },
            };
        }

        public Task<IList<Product>> GetAll()
        {
            return Task.FromResult<IList<Product>>(_products);
        }

        public Task<Product> Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NotImplementedException();
            }
             return Task.FromResult(product);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product item)
        {
            throw new NotImplementedException();
        }

        public Task Create(int id, Product item)
        {
            throw new NotImplementedException();
        }
    }
}
