using Microsoft.AspNetCore.Mvc;

namespace LocadoraAutomoveis.WebApp.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
