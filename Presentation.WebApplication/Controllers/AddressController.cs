using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using Shop.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApplication.Controllers
{
    public class AddressController : Controller
    {
        public static int selectedAddressId;
        private AddressNH addressRepository = new AddressNH();
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Address();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Address model)
        {
            // if address exist in database dont add
            var id = addressRepository.GetId(model);
            if(id == 0)
            {
                addressRepository.Add(model);
                id = addressRepository.GetId(model);
            }
            selectedAddressId = id;
            // else add new address
            var returnUrl = HttpContext.Request.Query["returnurl"];
            if(string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Product");
            }
            return Redirect(returnUrl);
        }
    }
}
