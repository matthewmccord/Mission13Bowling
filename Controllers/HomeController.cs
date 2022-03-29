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

        public IActionResult Index()
        {
            ViewBag.TeamList = _repo.Teams.ToList();

            var bowlingList = _repo.Bowlers
                .ToList();

            

            return View(bowlingList);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
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
            var specificBowler = _repo.Bowlers.Single(x=> x.BowlerID == bowlerid);
            return View("AddBowler", specificBowler);
        }

        [HttpPost]
        public IActionResult Edit (Bowler b)
        {

            _repo.SaveBowler(b);

            return View("Confirm", b);
        }
        
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
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
