using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext _appDBContext;

        public string _ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;

            string ShoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", ShoppingCartId);

            var context = services.GetService<AppDBContext>();
            return new ShoppingCart(context) { _ShoppingCartId = ShoppingCartId };
        }

        public void AddItemToCart(Product product, decimal amount)
        {
            var ShoppingCartItem = _appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == _ShoppingCartId
            );

            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = _ShoppingCartId,
                    Product = product,
                    Amount = amount
                };

                _appDBContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {
                //Do nothing as product already in cart
            }
            _appDBContext.SaveChanges();
        }

        public void RemoveItemFromCart(Product product)
        {
            var ShoppingCartItem = _appDBContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == _ShoppingCartId
            );

            if (ShoppingCartItem != null)
            {
                _appDBContext.ShoppingCartItems.Remove(ShoppingCartItem);
            }
            else
            {
                //Do nothing as product not in cart
            }
            _appDBContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            this.ShoppingCartItems = _appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == _ShoppingCartId
            ).Include(cart => cart.Product).ToList();

            return this.ShoppingCartItems;
        }

        public decimal GetShoppingCartTotal()
        {
            return _appDBContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == _ShoppingCartId
            ).Select(c => c.Amount).Sum();
        }

        public void ClearShoppingCart()
        {
            var ShoppingCartItems = _appDBContext.ShoppingCartItems.Where(
                cart => cart.ShoppingCartId == _ShoppingCartId
            );
            _appDBContext.ShoppingCartItems.RemoveRange(ShoppingCartItems);

            _appDBContext.SaveChanges();
        }
    }
}
