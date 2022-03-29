using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Models.ViewModels
{
    public class TeamViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public IQueryable<Team> Teams { get; set; }
    }
}
