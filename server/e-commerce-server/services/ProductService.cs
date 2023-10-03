using System;
using System.Collections.Generic;
using System.Linq;

namespace e_commerce_server
{
    public class ProductService
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

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
