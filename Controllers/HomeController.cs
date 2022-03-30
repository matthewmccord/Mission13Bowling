using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13Bowling.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            ViewBag.TeamList = _repo.Teams.ToList();
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            var bowlingList = _repo.Bowlers
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .OrderBy(b => b.BowlerLastName)
                .ToList();

            

            return View(bowlingList);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.TeamList = _repo.Teams.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TeamList = _repo.Teams.ToList();
                int teamIdHigh = _repo.Bowlers.OrderBy(x => x.BowlerID).Last().BowlerID;

                b.BowlerID = teamIdHigh + 1;
                _repo.CreateBowler(b);

                return View("Confirm", b);
            }
            else
            {
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.TeamList = _repo.Teams.ToList();
            var specificBowler = _repo.Bowlers.Single(x=> x.BowlerID == bowlerid);
            return View("AddBowler", specificBowler);
        }

        [HttpPost]
        public IActionResult Edit (Bowler b)
        {

            ViewBag.TeamList = _repo.Teams.ToList();
            _repo.SaveBowler(b);

            return View("Confirm", b);
        }
        
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            ViewBag.TeamList = _repo.Teams.ToList();
            var specificBowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            
            return View(specificBowler);
        }
        
        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
