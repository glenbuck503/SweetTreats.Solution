using Microsoft.AspNetCore.Mvc;
using SweetTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace SweetTreats.Controllers
{
  public class TreatsController : Controller 
  {
    private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [Authorize]
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTreats);
    }

    public ActionResult Create()
    {
      return View();
    }

   [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = treat.TreatId });
    }
  }
}