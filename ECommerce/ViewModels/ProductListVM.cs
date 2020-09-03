using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.ViewModels
{
    public class ProductListVM
    {
        public IEnumerable<Product> Products { get; set; }
        public string SelectedCategoryName { get; set; }
    }
}
