using HeroApp.Data;
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
        
        private readonly ApplicationDBContext dbContext;
        public TeamController(ApplicationDBContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }


        [Route("")]
        public IActionResult Index() //Displays all the records in the Teams table. 
        {
            var allTeams = dbContext.Teams.ToList();
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
            dbContext.Teams.Add(TeamValues); //Adds the record. 
            dbContext.SaveChanges();  //Saves the changes made to the record
            return RedirectToAction("Index"); //Takes you back to the Teams page.
        }


        [Route("DeleteTeam/{TeamID:int}")]
        public IActionResult DeleteTeam(int TeamID)
        {
            var count = dbContext.Heros.Count(t => t.TeamID == TeamID);
            for (int i = 0; i < count; i++)
            {
                var record = dbContext.Heros.FirstOrDefault(h => h.TeamID == TeamID);
                dbContext.Heros.Remove(record);
                dbContext.SaveChanges();
            }
            var TeamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID); //Finds the record in the table to delete
            dbContext.Teams.Remove(TeamValues); //executes sql quiry to delete table.
            dbContext.SaveChanges(); //Saves the changes.
            return RedirectToAction("Index");
        }


        [Route("EditTeam/{TeamID:int}")]
        public IActionResult EditTeam(int TeamID)
        {
            var TeamById = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID);
            return View(TeamById);
        }
        [HttpPost]
        [Route("EditTeam/{TeamID:int}")]
        public IActionResult EditTeam(Team team, int TeamID)
        {
            var TeamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID); //Finding the team by Id
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
            dbContext.SaveChanges(); //saves the changes. 
            return RedirectToAction("Index");
        }


        [Route("AddHero/{TeamID:int}")]
        public IActionResult AddHero(int TeamID)
        {
            var teamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID);
            ViewBag.TeamName = teamValues.TeamName;
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
                DateOfBirth = bindingModel.Rival,
                Team = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID),
                Photo = "http://pm1.narvii.com/5825/6f8f51442d37f9d637fe16c34eceb9f4299cefb9_00.jpg",
            };
            dbContext.Heros.Add(HeroValues);
            dbContext.SaveChanges();
            return RedirectToAction("ViewHeros", new {id = TeamID });
        }


        [Route("{id:int}/Heros")]
        public IActionResult ViewHeros(int id)
        {
            var team = dbContext.Teams.FirstOrDefault(t => t.TeamID == id);
            var heros = dbContext.Heros.Where(h => h.Team.TeamID == id).ToList();
            ViewBag.TeamName = team.TeamName;
            return View(heros);
        }

    }
}
