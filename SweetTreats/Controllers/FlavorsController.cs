using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetTreats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Patisserie.Controllers
{
  public class FlavorsController : Controller 
  {
    private readonly SweetTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(UserManager<ApplicationUser> userManager, SweetTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [Authorize]
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userFlavors = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userFlavors);
    }

    [Authorize]
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null? userId == thisFlavor.User.Id : false;
      return View(thisFlavor);
    }

    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
      if(thisFlavor == null)
      {
        return RedirectToAction("Details", new { id = id});
      }
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId});
    }

    [Authorize]
    public async Task<ActionResult> AddTreat(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
      if(thisFlavor == null)
      {
        return RedirectToAction("Details", new { id = id});
      }
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Type");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if(TreatId != 0)
      {
        var returnedJoin = _db.TreatFlavor
          .Any(join => join.FlavorId == flavor.FlavorId && join.TreatId == TreatId);
          if(!returnedJoin)
          {
            _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
          }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
    
      
    