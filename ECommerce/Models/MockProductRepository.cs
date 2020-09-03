using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class MockProductRepository : IProductsRepository
    {
        private readonly ICategoryRepository categoryRepository;
        public MockProductRepository(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }
        public IEnumerable<Product> AllProducts => new List<Product>
        {
            new Product
            {
                ProductId = 1, Name = "Gildan Adult T Shirt", Description = "Cotton 100%. Machine wash. For men or women.",
                Fee = 5, ImageUrl = "https://i5.walmartimages.ca/images/Enlarge/221/602/6000198221602.jpg", HasFastShipping = true,
                Category = categoryRepository.AllCategories.ToList()[0]
            },
            new Product
            {
                ProductId = 2, Name = "RCA Microwave", Description = "RCA 0.7 Cu. Ft. Microwave Oven",
                Fee = 50, ImageUrl = "https://i5.walmartimages.ca/images/Enlarge/577/297/999999-5846577297.jpg", HasFastShipping = false,
                Category = categoryRepository.AllCategories.ToList()[2]
            },
            new Product
            {
                ProductId = 3, Name = "Acer Aspire", Description = "Acer Aspire 3 15.6 Laptop Intel Core i5-6300U A315-54K-529G",
                Fee = 528, ImageUrl = "https://i5.walmartimages.ca/images/Enlarge/929/862/6000201929862.jpg", HasFastShipping = true,
                Category = categoryRepository.AllCategories.ToList()[1]
            },
            new Product
            {
                ProductId = 4, Name = "DJI Ryze Tello Drone", Description = "Shoot quick videos with EZ Shots, and learn about drones with coding education.",
                Fee = 139, ImageUrl = "https://i5.walmartimages.ca/images/Enlarge/088/114/6000198088114.jpg", HasFastShipping = false,
                Category = categoryRepository.AllCategories.ToList()[1]
            },
            new Product
            {
                ProductId = 5, Name = "Danby Refrigerator", Description = "Danby Products Danby Designer 3.1 cu.ft 2-Door Compact Refrigerator",
                Fee = 229, ImageUrl = "https://i5.walmartimages.ca/images/Enlarge/999/212/999999-67638999212.jpg", HasFastShipping = false,
                Category = categoryRepository.AllCategories.ToList()[2]
            }
        };

        public IEnumerable<Product> DiscountedProducts { get; }

        public Product GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
