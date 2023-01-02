using System;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index() //after the method is called, it returns the Index.cshtml view containing the "MyView" header and the string "Good morning"/"Good afternoon"/"Good evening"
        {
            string greeting;
            DateTime time = DateTime.Now;
            int hour = time.Hour;
            if (hour < 12)
            {
                greeting = "Good morning";
            }
            else if (hour < 18)
            {
                greeting = "Good afternoon";
            }
            else
            {
                greeting = "Good evening";
            }
            return View("MyView", greeting); //"MyView" is the name of the view file, and "greeting" is the model object passed to return
        }
    }
}