using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductsRepository productsRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productsRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public ViewResult List()
        {
            //ViewBag.SelectedCategory = _categoryRepository.AllCategories.ToList()[2].Name;
            //return View(_productRepository.AllProducts);

            ProductListVM productListVM = new ProductListVM()
            {
                Products = _productRepository.AllProducts,
                SelectedCategoryName = _categoryRepository.AllCategories.ToList()[2].Name
            };

            return View(productListVM);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

    }
}
