using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class EFProductRepository : IProductsRepository
    {
        private readonly AppDBContext _appDBContext;

        public EFProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IEnumerable<Product> AllProducts 
        {
            get
            {
                return _appDBContext.Products.Include(p => p.Category);
            }
        }

        public IEnumerable<Product> DiscountedProducts => throw new NotImplementedException();

        public Product GetProductById(int productId)
        {
            return _appDBContext.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
