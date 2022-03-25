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
            var bowlingList = _repo.Bowlers
                .ToList();

            return View(bowlingList);
        }

        
    }
}
