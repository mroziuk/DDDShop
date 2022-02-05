using Microsoft.AspNetCore.Mvc;
using Presentation.WebApplication.Models;
using Shop.Application;
using Shop.Domain.Exceptions;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApplication.Controllers
{
    public class CartController : Controller
    {
        private static Cart cart = new Cart();
        private ShopService _shopService = new ShopService();
        private IProductRepository productRepository = new ProductNH();
        private Order _order = new Order();
        [HttpGet]
        public IActionResult Index()
        {
            return View(cart.order.OrderProducts);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IEnumerable<Product> products, Address address)
        {
            if(this.ModelState.IsValid)
            {
                if(cart.order.OrderProducts.Count == 0)
                {
                    throw new EmptyOrderException();
                }
                _shopService.AddNewOrder(cart.order);
                cart.order = new Order();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(products);
            }
        }
        public IActionResult AddtoCart(int productId)
        {
            var product = productRepository.Find(productId);
            if(product == null)
            {
                throw new ProductNotFoundException(productId);
            }
            _shopService.AddProductToOrder(cart.order, product);
            var returnUrl = HttpContext.Request.Query["returnurl"];
            if(string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Product");
            }
            return Redirect(returnUrl);
        }
        public IActionResult ClearCart()
        {
            cart.order = new Order();
            var returnUrl = HttpContext.Request.Query["returnurl"];
            if(string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Product");
            }
            return Redirect(returnUrl);
        }



        public static int selectedAddressId;
        private AddressNH addressRepository = new AddressNH();
        [HttpGet]
        public IActionResult SelectAddress()
        {
            var model = new Address();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SelectAddress(Address model)
        {
            //if address exist in database dont add
            var id = addressRepository.GetId(model);
            if(id == 0)
            {
                addressRepository.Add(model);
                id = addressRepository.GetId(model);
            }

            cart.addressToId = 1;
            return RedirectToAction("Index", "Cart");
        }
    }
}
