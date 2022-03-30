using Microsoft.AspNetCore.Mvc;
using Mission13Bowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private IBowlersRepository _repo { get; set; }

        public TeamViewComponent (IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];
            
            var teamNames = _repo.Teams.Select(x => x.TeamName).Distinct().OrderBy(x => x);

            return View(teamNames);
        }
    }
}
