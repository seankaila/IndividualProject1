using HeroApp.Data;
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
                Logo = "https://www.pngitem.com/pimgs/m/5-50673_superman-logo-vector-blank-superman-logo-png-transparent.png", //Add if statement for emptyLogo. 
            };
            dbContext.Teams.Add(TeamValues); //Adds the record. 
            dbContext.SaveChanges();  //Saves the changes made to the record
            return RedirectToAction("Index"); //Takes you back to the Teams page.
        }


        [Route("DeleteTeam/{TeamID:int}")]
        public IActionResult DeleteTeam(int TeamID)
        {
            var TeamValues = dbContext.Teams.FirstOrDefault(t => t.TeamID == TeamID); //Finds the record in the table to delete
            dbContext.Teams.Remove(TeamValues); //executes sql quiry to delete table.
            dbContext.SaveChanges(); //Saves the changes.
            return RedirectToAction("Index");
        }


    }
}
