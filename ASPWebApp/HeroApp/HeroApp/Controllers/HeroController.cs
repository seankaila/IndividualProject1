using HeroApp.Data;
using HeroApp.Interfaces;
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
        //private readonly ApplicationDBContext dbContext;
        private IRepositoryWrapper repository;
        public HeroController(IRepositoryWrapper repositoryWrapper)
        {
            //dbContext = applicationDbContext;
            repository = repositoryWrapper;
        }
        [Route("")]
        public IActionResult Index()
        {
            var allHeros = repository.Heros.FinalALL();
            //var allHeros = dbContext.Heros.ToList();
            return View(allHeros);
        }


        [Route("EditHero/{HeroID:int}")]
        public IActionResult EditHero(int HeroID)
        {
            var HeroById = repository.Heros.FindByCondition(t => t.HeroID == HeroID).FirstOrDefault();
            //var HeroById = dbContext.Heros.FirstOrDefault(t => t.HeroID == HeroID);
            return View(HeroById);
        }
        [HttpPost]
        [Route("EditHero/{HeroID:int}")]
        public IActionResult EditHero(Hero hero, int HeroID)
        {
            var HeroValues = repository.Heros.FindByCondition(t => t.HeroID == HeroID).FirstOrDefault();
            //var HeroValues = dbContext.Heros.FirstOrDefault(h => h.HeroID == HeroID); //Finding the team by Id
            HeroValues.FirstName = hero.FirstName;
            HeroValues.LastName = hero.LastName; //Replacing what was entered against what needs to be changed. 
            HeroValues.Alias = hero.Alias;
            HeroValues.DateOfBirth = hero.DateOfBirth;
            HeroValues.Rival = hero.Rival;
            HeroValues.Power = hero.Power;
            HeroValues.Photo = hero.Photo;
            repository.Heros.Update(HeroValues);
            repository.Save();
            //dbContext.SaveChanges(); //saves the changes. 
            return RedirectToAction("ViewHeros", "Team", new { id = hero.TeamID });
        }


        [Route("DeleteHero/{HeroID:int}")]
        public IActionResult DeleteHero(int HeroID)
        {
            var HeroValues = repository.Heros.FindByCondition(t => t.HeroID == HeroID).FirstOrDefault();
            //var HeroValues = dbContext.Heros.FirstOrDefault(h => h.HeroID == HeroID); //Finds the record in the table to delete
            repository.Heros.Delete(HeroValues);
            //dbContext.Heros.Remove(HeroValues); //executes sql quiry to delete table.
            repository.Save();
            //dbContext.SaveChanges(); //Saves the changes.
            return RedirectToAction("ViewHeros", "Team", new { id = HeroValues.TeamID });
        }


        [Route("HeroDetails/{HeroID:int}")]
        public IActionResult HeroDetails(int HeroID)
        {
            var HeroById = repository.Heros.FindByCondition(t => t.HeroID == HeroID).FirstOrDefault();
            //var HeroById = dbContext.Heros.FirstOrDefault(h => h.HeroID == HeroID);
            return View(HeroById);
        }


    }
}
