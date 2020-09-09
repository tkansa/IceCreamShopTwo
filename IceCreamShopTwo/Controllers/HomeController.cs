using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IceCreamShopTwo.Models;
using Microsoft.Extensions.Configuration;
using IceCreamShopTwo.Services;

namespace IceCreamShopTwo.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration configRoot;
        IDAL dal;

        public HomeController(IDAL dalObject)
        {
            // configRoot = config;
            //connection = new SqlConnection(configRoot.GetConnectionString("iceCreamDB"));
            //dal = new DALSqlServer(configRoot.GetConnectionString("iceCreamDB"));    
            dal = dalObject;
        }

        public IActionResult Index()
        {
           
            ViewData["Products"] = dal.GetCategories();
            return View();
        }

        public IActionResult Cat(string cat)
        {
           

            ViewData["Title"] = cat;
            ViewData["Products"] = dal.GetProductsInCategory(cat);
            return View();
        }

        public IActionResult Detail(int id)
        {
            Product product = dal.GetProductById(id);

            if(product == null)
            {
                return View("NoSuchItem");
            }
            else
            {
                ViewData["Title"] = product.Name;
                ViewData["Product"] = product;
                return View();
            }

            

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
