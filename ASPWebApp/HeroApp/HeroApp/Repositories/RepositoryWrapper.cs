using HeroApp.Data;
using HeroApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDBContext _repoContext;
        public RepositoryWrapper(ApplicationDBContext repoContext)
        {
            _repoContext = repoContext;
        }
        ITeamRepository _teams;

        IHeroRepository _heros;

        public ITeamRepository Teams
        {
            get
            {
                if (_teams == null)
                {
                    _teams = new TeamRepository(_repoContext);
                }
                return _teams;
            }
        }
        public IHeroRepository Heros
        {
            get
            {
                if (_heros == null)
                {
                    _heros = new HeroRepository(_repoContext);
                }
                return _heros;
            }
        }
        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
