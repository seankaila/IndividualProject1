using HeroApp.Controllers;
using HeroApp.Interfaces;
using HeroApp.Models;
using HeroApp.Models.Binding;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HeroAppTests
{
    public class HeroControllerUnitTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private HeroController heroController;
        private TeamController teamController;
        private AddTeamBindingModel addTeam;


        public HeroControllerUnitTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();
            var allHeros = GetHero();
            heroController = new HeroController(mockRepo.Object);
            teamController = new TeamController(mockRepo.Object);
            addTeam = new AddTeamBindingModel { TeamID = 3, TeamName = "JusticeLeague", City = "Gotham", EstablishedDate = "20/03/1998", RivalTeam = "Legion Of Doom", Logo = "logo.png" };

        }

        [Fact]
        public void GetAllHeros_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Heros.FinalALL()).Returns(GetHeros);
            //Act
            var controllerActionResult = heroController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);


        }

        [Fact]
        public void EditHero_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Heros.FindByCondition(r => r.HeroID == It.IsAny<int>())).Returns(GetHeros());
            mockRepo.Setup(repo => repo.Heros.Update(GetHero()));
            //Act
            var controllerActionResult = heroController.EditHero(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);

        }

        [Fact]
        public void DeleteHero_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Teams.FindByCondition(r => r.TeamID == It.IsAny<int>())).Returns(GetTeams());
            mockRepo.Setup(repo => repo.Heros.FindByCondition(r => r.HeroID == It.IsAny<int>())).Returns(GetHeros());
            mockRepo.Setup(repo => repo.Heros.Delete(GetHero()));
            //Act
            heroController.DeleteHero(It.IsAny<int>());

        }
        [Fact]
        public void HeroDetails_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Heros.FinalALL()).Returns(GetHeros);
            //Act
            var controllerActionResult = heroController.HeroDetails(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);


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
    }

}
