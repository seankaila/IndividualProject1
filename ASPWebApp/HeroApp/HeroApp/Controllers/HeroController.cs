using HeroApp.Data;
using HeroApp.Models;
using HeroApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    [Route("[Controller]")]
    public class HeroController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public HeroController(ApplicationDBContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        [Route("")]
        public IActionResult Index()
        {
            var allHeros = dbContext.Heros.ToList();
            return View(allHeros);
        }



 




    }
}
