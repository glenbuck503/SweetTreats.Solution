using Microsoft.AspNetCore.Mvc;

namespace SweetTreats.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}