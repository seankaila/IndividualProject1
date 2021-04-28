using HeroApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public TeamController(ApplicationDBContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var allTeams = dbContext.Teams.ToList();
            return View(allTeams);
        }


    }
}
