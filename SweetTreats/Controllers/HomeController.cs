using SweetTreats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SweetTreats.Controllers
{
  public class HomeController : Controller
  {
    private readonly SweetTreatsContext _db;
    public HomeController(SweetTreatsContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.Flavors = _db.Flavors.ToList();
      ViewBag.Treats = _db.Treats.ToList();
      return View();
    }
  }
}