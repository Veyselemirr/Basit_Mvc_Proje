using Microsoft.AspNetCore.Mvc;

namespace OOP_Project.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
