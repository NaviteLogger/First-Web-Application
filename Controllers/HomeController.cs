using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            return View("MyView");
        }
    }
}