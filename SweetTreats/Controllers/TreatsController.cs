using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SweetTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetTreats.Controllers
{
  [Authorize]
  public class TreatsController : Controller 
  {
     private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTreats);
    }

    [Authorize]
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