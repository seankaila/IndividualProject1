using System;
using Xunit;
using HeroApp;
using HeroApp.Interfaces;
using Moq;
using HeroApp.Controllers;
using HeroApp.Models;
using System.Collections.Generic;
using System.Linq;
using HeroApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace HeroAppTests
{
    public class TeamControllerUnitTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
       // private Mock<ITeam> iteam;
       // private List<ITeam> teams;
        private TeamController teamController;
        private Team team;
        private Hero hero;
        private Team editTeam;
        private AddTeamBindingModel addTeam;
        private AddHeroBindingModel addHero;

        public TeamControllerUnitTest()
        {
            addTeam = new AddTeamBindingModel { TeamID = 3, TeamName = "JusticeLeague", City = "Gotham", EstablishedDate = "20/03/1998", RivalTeam = "Legion Of Doom", Logo = "logo.png" };
            addHero = new AddHeroBindingModel { HeroID = 3, FirstName = "Barry", LastName = "Alllen", DateOfBirth = "20/03/1998", Rival = "Reverse Flash", Photo = "logo.png", Alias = "The Flash", Power = "Speed", TeamID = 1};
            editTeam = new Team { TeamID = 3, TeamName = "Avengers", City = "LA", EstablishedDate = "20/03/2012", RivalTeam = "Thanos ", Logo = "logo.png" };
            team = new Team { TeamID = 3, TeamName = "JusticeLeague", City = "Gotham", EstablishedDate = "20/03/1998", RivalTeam = "Legion Of Doom", Logo = "logo.png" };
            mockRepo = new Mock<IRepositoryWrapper>();
            var allTeams = GetTeam();
            var allHeros = GetHero();
            teamController = new TeamController(mockRepo.Object);
        }
        [Fact]
        public void GetAllTeams_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo=>repo.Teams.FinalALL()).Returns(GetTeams);
            //Act
            var controllerActionResult = teamController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
           

        }
        [Fact]
        public void AddTeam_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Teams.FindByCondition(t => t.TeamID == It.IsAny<int>())).Returns(GetTeams);
            //Act
            var controllerActionResult = teamController.AddTeam(addTeam);
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        /*
        [Fact]
        public void DeleteTeam_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Teams.FindByCondition(t => t.TeamID == It.IsAny<int>())).Returns(GetTeams);
            int teamID = team.TeamID;
            //Act
            var controllerActionResult = teamController.DeleteTeam(teamID);
            //Assert

        }*/
        [Fact]
        public void EditTeam_Test()
        { /*
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Teams.FindByCondition(t => t.TeamID == It.IsAny<int>())).Returns(GetTeams);
            
            //Act
            var controllerActionResult = teamController.AddTeam(addTeam);
            var controllerActionResult2 = teamController.EditTeam(editTeam, 3);
            //Assert
            Assert.NotNull(controllerActionResult2); */
            //Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Teams.FindByCondition(t => t.TeamID == It.IsAny<int>())).Returns(GetTeams);
            
            var controllerActionResult2 = teamController.EditTeam(editTeam, 3);
            Assert.NotNull(controllerActionResult2);
        }

        [Fact]
        public void AddHero_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Teams.FindByCondition(t => t.TeamID == It.IsAny<int>())).Returns(GetTeams);
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult2 = mockRepo.Setup(repo => repo.Heros.FindByCondition(h => h.HeroID == It.IsAny<int>())).Returns(GetHeros);
            int teamID = team.TeamID;
            //Act
            var controllerActionResult = teamController.AddTeam(addTeam);
            var controllerActionResult2 = teamController.AddHero(addHero,teamID);
            //Assert
            Assert.NotNull(controllerActionResult2);
        }


        private IEnumerable<Team> GetTeams()
        {
            var teams = new List<Team>
            {
               new Team(){TeamID = 1, TeamName = "JusticeLeague", City = "Gotham", EstablishedDate = "20/03/1998", RivalTeam = "Legion Of Doom", Logo = "logo.png" },
               new Team(){TeamID = 2, TeamName = "Avengers", City = "LA", EstablishedDate = "20/03/2012", RivalTeam = "Thanos and Gang", Logo = "logo.png" }
            };
            return teams;
        }
        private Team GetTeam()
        {
            return GetTeams().ToList()[0];
        }

        private IEnumerable<Hero> GetHeros()
        {
            var heros = new List<Hero>
            {
               new Hero(){HeroID = 1, FirstName = "Bruce", LastName = "Wayne", DateOfBirth = "20/03/1998", Rival = "Joker", Photo = "logo.png", Alias = "Batman", Power = "Im Rich", TeamID = 1 },
               new Hero(){HeroID = 2, FirstName = "Diana", LastName = "Prince", DateOfBirth = "20/03/1998", Rival = "Airis", Photo = "logo.png", Alias = "Wonder Woman", Power = "God", TeamID = 1 }
            };
            return heros;
        }
        private Hero GetHero()
        {
            return GetHeros().ToList()[0];
        }
    }
}