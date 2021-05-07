using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string RivalTeam { get; set; }
        public string EstablishedDate { get; set; }
        public string Logo { get; set; }

        public virtual List<Hero> Hero { get; set; }
    }
}
//Small change