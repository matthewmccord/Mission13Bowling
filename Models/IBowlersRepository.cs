using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get;  }
    }
}
