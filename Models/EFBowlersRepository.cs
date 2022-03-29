using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler bowler)
        {
            //I think I still need to handle the issue if the purchase ID is the same
            _context.SaveChanges();
        }

        public void CreateBowler(Bowler bowler)
        {
            _context.Add(bowler);
            _context.SaveChanges();

        }

        public void DeleteBowler(Bowler bowler)
        {
            _context.Remove(bowler);
            _context.SaveChanges();
        }
    }
}
