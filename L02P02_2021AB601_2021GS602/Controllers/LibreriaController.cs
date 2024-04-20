using L02P02_2021AB601_2021GS602.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2021AB601_2021GS602.Controllers
{
    public class LibreriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
