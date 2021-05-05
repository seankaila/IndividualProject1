using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITeamRepository Teams { get;}

        IHeroRepository Heros { get;}

        void Save();
    }
}
