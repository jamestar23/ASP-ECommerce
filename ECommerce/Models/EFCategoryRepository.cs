using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _appDBContext;
        public EFCategoryRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IEnumerable<Category> AllCategories => _appDBContext.Categories;
    }
}
