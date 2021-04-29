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


        [Route("EditHero/{HeroID:int}")]
        public IActionResult EditHero(int HeroID)
        {
            var HeroById = dbContext.Heros.FirstOrDefault(t => t.HeroID == HeroID);
            return View(HeroById);
        }
        [HttpPost]
        [Route("EditHero/{HeroID:int}")]
        public IActionResult EditHero(Hero hero, int HeroID)
        {
            var HeroValues = dbContext.Heros.FirstOrDefault(t => t.HeroID == HeroID); //Finding the team by Id
            HeroValues.FirstName = hero.FirstName;
            HeroValues.LastName = hero.LastName; //Replacing what was entered against what needs to be changed. 
            HeroValues.Alias = hero.Alias;
            HeroValues.DateOfBirth = hero.DateOfBirth;
            HeroValues.Rival = hero.Rival;
            HeroValues.Power = hero.Power;
            HeroValues.Photo = hero.Photo;
            dbContext.SaveChanges(); //saves the changes. 
            return RedirectToAction("Index");
        }






    }
}
