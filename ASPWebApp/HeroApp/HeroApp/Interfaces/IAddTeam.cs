using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Interfaces
{
    public interface IAddTeam
    {
        public int HeroID { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rival { get; set; }
        public string Power { get; set; }
        public string DateOfBirth { get; set; }
        public string Photo { get; set; }
        public int TeamID { get; set; }
    }
}
