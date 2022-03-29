using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get;  }
        IQueryable<Team> Teams { get; }
        public void CreateBowler(Bowler bowler);
        public void SaveBowler(Bowler bowler);
        public void DeleteBowler(Bowler bowler);

    }
}
