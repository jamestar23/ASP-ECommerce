using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductsRepository productsRepository, ShoppingCart cart)
        {
            _productsRepository = productsRepository;
            _shoppingCart = cart;
        }

        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            return View(_shoppingCart);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productsRepository.GetProductById(productId);
            _shoppingCart.AddItemToCart(selectedProduct, selectedProduct.Fee);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productsRepository.GetProductById(productId);
            _shoppingCart.RemoveItemFromCart(selectedProduct);

            return RedirectToAction("Index");
        }
    }
}
