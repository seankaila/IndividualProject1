using System;

namespace HeroApp
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string RivalTeam { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Logo { get; set; }
    }
}
