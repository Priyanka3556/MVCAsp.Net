using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccessLayer;
using DataAccessLayer.Enums;
using TecsysRetailCoding.Models;

namespace TecsysRetailCoding.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ProductsManager manager = new ProductsManager();
        // GET: /Home/Default
        [AllowAnonymous]
        public ActionResult Default(string returnUrl)
        {
            var model = (HomeViewModel)TempData["model"];
            if(model!=null && model.CarProducts.Any())
                return View(model);
            ViewBag.ReturnUrl = returnUrl;
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.CarProducts = manager.GetProducts(Category.Cars);
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("SearchProducts")]
        public ActionResult SearchProducts(HomeViewModel model, string searchCriteria)
        {
            if (manager.ValidateSearchCriteria(searchCriteria))
            {
                model.SearchProducts = new SearchProducts();
                model.SearchProducts.Products = manager.SearchProducts(searchCriteria);
                if (model.SearchProducts.Products == null || !model.SearchProducts.Products.Any())
                    model.SearchProducts.IsSuccess = false;
              
                model.SearchProducts.IsSuccess = true;
                TempData["model"] = model;
                return RedirectToAction("Default");
                //return PartialView("Default", model);
            }

            return Content("Please enter more than 2 letters to search");
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("AddToCart")]
        public JsonResult AddToCart(List<int> items)
        {
            var cartItems = manager.ProcessCartItems(items);
            bool result =  manager.AddCartItems(cartItems);
            return Json(new { success = result });
        }
    }
}
