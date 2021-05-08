using HeroApp.Data;
using HeroApp.Interfaces;
using HeroApp.Models;
using HeroApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroApp.Controllers
{
    [Route("[Controller]")]
    public class TeamController : Controller
    {

        private IRepositoryWrapper repository;
        public TeamController(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;
        }


        [Route("")]
        public IActionResult Index() //Displays all the records in the Teams table. 
        {
            var allTeams = repository.Teams.FinalALL();
            //var allTeams = dbContext.Teams.ToList();
            return View(allTeams);  
        }


        [Route("AddTeam")]
        public IActionResult AddTeam() 
        {
            return View();
        }
        [HttpPost("AddTeam")]
        public IActionResult AddTeam(AddTeamBindingModel bindingModel) //Adds a record to the teams table. 
        {
            var TeamValues = new Team
            {
                TeamName = bindingModel.TeamName,
                City = bindingModel.City,
                EstablishedDate = bindingModel.EstablishedDate,
                RivalTeam = bindingModel.RivalTeam,
                Logo = bindingModel.Logo,
            };
            string png = ".png";
            string jpeg = ".jpeg";
            string jpg = ".jpg";
            if (bindingModel.Logo == null)
            {
                TeamValues.Logo = "https://www.pngitem.com/pimgs/m/5-50673_superman-logo-vector-blank-superman-logo-png-transparent.png";
            }
            repository.Teams.Create(TeamValues);
            //dbContext.Teams.Add(TeamValues); //Adds the record.
            repository.Save();
            //dbContext.SaveChanges();  //Saves the changes made to the record
            return RedirectToAction("Index"); //Takes you back to the Teams page.
        }

        
        [Route("DeleteTeam/{TeamID:int}")]
        public IActionResult DeleteTeam(int TeamID)
        {
            var count = repository.Heros.FindByCondition(t => t.TeamID == TeamID).Count();
            //var count = dbContext.Heros.Count(t => t.TeamID == TeamID);
            for (int i = 0; i < count; i++)
            {
                var record = repository.Heros.FindByCondition(h => h.TeamID == TeamID).FirstOrDefault();
                //var record = dbContext.Heros.FirstOrDefault(h => h.TeamID == TeamID);
                repository.Heros.Delete(record);
                //dbContext.Heros.Remove(record);
                repository.Save();
                //dbContext.SaveChanges();
            }
            var TeamValues = repository.Teams.FindByCondition(t => t.TeamID == TeamID).FirstOrDefault();
            //var TeamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID); //Finds the record in the table to delete
            repository.Teams.Delete(TeamValues);
            //dbContext.Teams.Remove(TeamValues); //executes sql quiry to delete table.
            repository.Save();
            //dbContext.SaveChanges(); //Saves the changes.
            return RedirectToAction("Index");
        }
        
        
        [Route("EditTeam/{TeamID:int}")]
        public IActionResult EditTeam(int TeamID)
        {
            var TeamById = repository.Teams.FindByCondition(t => t.TeamID == TeamID).FirstOrDefault();
            //var TeamById = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID);
            return View(TeamById);
        }
        [HttpPost]
        [Route("EditTeam/{TeamID:int}")]
        public IActionResult EditTeam(Team team, int TeamID)
        {
            var TeamValues = repository.Teams.FindByCondition(t => t.TeamID == TeamID).FirstOrDefault();
            //var TeamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID); //Finding the team by Id
            TeamValues.TeamName = team.TeamName; //Replacing what was entered against what needs to be changed. 
            TeamValues.City = team.City;
            TeamValues.EstablishedDate = team.EstablishedDate;
            TeamValues.RivalTeam = team.RivalTeam;
            TeamValues.Logo = team.Logo;
            string png = ".png";
            string jpeg = ".jpeg";
            string jpg = ".jpg";
            if (TeamValues.Logo == null)
            {
                TeamValues.Logo = "https://www.pngitem.com/pimgs/m/5-50673_superman-logo-vector-blank-superman-logo-png-transparent.png";
            }
            repository.Teams.Update(TeamValues);
            repository.Save();
            //dbContext.SaveChanges(); //saves the changes. 
            return RedirectToAction("Index");
        }

        
        [Route("AddHero/{TeamID:int}")]
        public IActionResult AddHero(int TeamID)
        {
            var teamValues = repository.Teams.FindByCondition(t => t.TeamID == TeamID).FirstOrDefault();
            //var teamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID);
            if (teamValues != null) { ViewBag.TeamName = teamValues.TeamName; }
            return View();
        }
        [HttpPost]
        [Route("AddHero/{TeamID:int}")]
        public IActionResult AddHero(AddHeroBindingModel bindingModel, int TeamID)
        {
            bindingModel.TeamID = TeamID;
            var HeroValues = new Hero
            {
                FirstName = bindingModel.FirstName,
                LastName = bindingModel.LastName,
                Alias = bindingModel.Alias,
                Rival = bindingModel.Rival,
                Power = bindingModel.Power,
                DateOfBirth = bindingModel.DateOfBirth,
                Team = repository.Teams.FindByCondition(t => t.TeamID == TeamID).FirstOrDefault(),
                 //Team = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID),
                Photo = "http://pm1.narvii.com/5825/6f8f51442d37f9d637fe16c34eceb9f4299cefb9_00.jpg",
            };
            repository.Heros.Update(HeroValues);
            //dbContext.Heros.Add(HeroValues);
            repository.Save();
            //dbContext.SaveChanges();
            return RedirectToAction("ViewHeros", new {id = TeamID });
        }

       
        [Route("{id:int}/Heros")]
        public IActionResult ViewHeros(int id)
        {
            var team = repository.Teams.FindByCondition(t => t.TeamID == id).FirstOrDefault();
            // var team = dbContext.Teams.FirstOrDefault(t => t.TeamID == id);
            var heros = repository.Heros.FindByCondition(h => h.TeamID == id).Where(h => h.TeamID == id);
            //var heros = dbContext.Heros.Where(h => h.Team.TeamID == id).ToList();
            if (team != null){ ViewBag.TeamName = team.TeamName;}
            return View(heros);
        }
        
    }
}
