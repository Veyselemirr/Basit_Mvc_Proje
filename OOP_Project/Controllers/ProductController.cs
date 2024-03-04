using Microsoft.AspNetCore.Mvc;
using OOP_Project.Entity;
using OOP_Project.ProjeContext;

namespace OOP_Project.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            var t = context.Products.Where(x => x.Id == id).FirstOrDefault();
            context.Products.Remove(t);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = context.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var values = context.Products.Where(x => x.Id == p.Id).FirstOrDefault();
            values.ProductName = p.ProductName;
            values.ProductPrice = p.ProductPrice;
            values.Stock = p.Stock;
            context.Products.Update(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
