using HeroApp.Data;
using HeroApp.Interfaces;
using HeroApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Repositories
{
    public class HeroRepository : Repositroy<Hero>, IHeroRepository
    {
        public HeroRepository(ApplicationDBContext dbContext) : base(dbContext)
        { 

        }
    }
}
