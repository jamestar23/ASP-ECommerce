using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> DiscountedProducts { get; }
        Product GetProductById(int productId);
    }
}
