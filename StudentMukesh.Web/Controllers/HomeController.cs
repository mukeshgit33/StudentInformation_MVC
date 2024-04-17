using Microsoft.AspNetCore.Mvc;
using StudentMukesh.Web.Models;
using System.Diagnostics;

namespace StudentMukesh.Web.Controllers
{
    public class HomeController : Controller
    {
       static int count = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //var, dynamic

        public IActionResult Index()
        {
          //var peopleList =  new List<People>();
          //  peopleList.Add(new People { Id = 1, Name = "tarun" });
          //  peopleList.Add(new People { Id = 2, Name = "Ram" });
          //  peopleList.Add(new People { Id = 3, Name = "Shyam" });
          //  peopleList.Add(new People { Id = 4, Name = "Mohan" });
          //  peopleList.Add(new People { Id = 5, Name = "Sohan" });
          //  peopleList.Add(new People { Id = 6, Name = "Monu" });
          //  peopleList.Add(new People { Id = 7, Name = "tarun" });
          //  peopleList.Add(new People { Id = 8, Name = "tarun" });
          //  peopleList.Add(new People { Id = 9, Name = "tarun" });
          //  peopleList.Add(new People { Id = 10, Name = "tarun" });
           

            return View(/*peopleList*/);
        }

        public IActionResult Privacy()
        {
          
            count++;
            string val = GetValue();
            return View("Index",count);
        }
        [NonAction]
        public string GetValue()
        {
            return "hello";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//Static  class 