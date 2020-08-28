using ShopTastic.Core.Contracts;
using ShopTastic.Core.Models;
using ShopTastic.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTastic.DataAccess.SQL;

namespace ShopTastic.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }


        public ActionResult Index(string searchString)
        {


            var products = from p in context.Collection()
                           select p;



            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Category.Contains(searchString));
            }



            return View(products.ToList());
            //List<Product> products = context.Collection().ToList();

            //return View();
        }
            
                     
         public  ActionResult FilterProduct(string category)

            {
                DataContext productContext = new DataContext();
                List<Product> filteredProduct = productContext.Products.Where(p => p.Category == category).ToList();

                return View(filteredProduct);
            }
        

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Help()
        {
            ViewBag.Message = "This is the help page.";
            return View();
        }
    }
}