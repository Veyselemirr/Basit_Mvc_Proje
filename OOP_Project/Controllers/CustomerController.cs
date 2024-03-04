using Microsoft.AspNetCore.Mvc;
using OOP_Project.Entity;
using OOP_Project.ProjeContext;

namespace OOP_Project.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            if (p.CustomerName.Length >= 6 && p.CustomerCity != "" && p.CustomerCity.Length >= 3)
            {
                context.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Hatalı Kullanım";
                return View();
            }

        }
        public IActionResult DeleteCustomer(int id)
        {
            var values = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            context.Customers.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var values = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            var t = context.Customers.Where(x => x.CustomerID == p.CustomerID).FirstOrDefault();
            t.CustomerID = p.CustomerID;
            t.CustomerName = p.CustomerName;
            t.CustomerCity = p.CustomerCity;
            context.Customers.Update(t);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
