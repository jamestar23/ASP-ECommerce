using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category
            {
                CategoryId = 101,
                Name = "Apparel",
                Description = "Shirts, Pants, Shoes etc."
            },
            new Category
            {
                CategoryId = 102,
                Name = "Electronics",
                Description = "Laptop, Phones, Drones etc."
            },
            new Category
            {
                CategoryId = 103,
                Name = "Appliances",
                Description = "Small, Large, Kitchen etc."
            },

        };
    }
}
