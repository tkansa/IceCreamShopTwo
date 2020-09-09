using Dapper;
using IceCreamShopTwo.Models;
using IceCreamShopTwo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IceCreamShopTwo.Controllers
{
    public class AdminController : Controller
    {
        IDAL dal;

        public AdminController(IDAL dalObject)
        {

            //connection = new SqlConnection(configRoot.GetConnectionString("iceCreamDB"));
            dal = dalObject;
        }

        public IActionResult Index()
        {
            
            ViewData["Products"] = dal.GetAllProducts();
            return View();
        }

       // [HttpPost]
        public IActionResult Add(Product product)
        {
            if(string.IsNullOrEmpty(product.Category))
            {
                Product p = new Product();
                return View("AddForm", p);
            }
            else { 
            int result = dal.CreateProduct(product);
            if (result == 1)
            {
                TempData["UserMsg"] = "Your item was added.";
            }

            return RedirectToAction("Index");
            }
        }

        public IActionResult AddForm()
        {
            Product product = new Product();
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            int result = dal.DeleteProductById(id);
            if(result == 1)
            {
                TempData["UserMsg"] = "Your item was deleted.";
            }

            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = dal.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            int result = dal.UpdateProductBy(product);
            if (result == 1)
            {
                TempData["UserMsg"] = "Your item was added.";
            }

            return RedirectToAction("Index");
        }
    }
}