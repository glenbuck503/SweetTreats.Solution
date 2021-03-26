using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetTreats.Models;
using SweetTreats.ViewModels;
using System;
using System.Threading.Tasks;

namespace SweetTreats.Controllers
{
  public class AccountController : Controller
  {
    private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
  }
}
