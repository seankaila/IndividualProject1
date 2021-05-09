using HeroApp.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HeroAppTests
{
    public class HomeControllerUnitTest
    {
        private Mock<ILogger<HomeController>> mockLogger;
        private HomeController homeController;

        public HomeControllerUnitTest()
        {
            mockLogger = new Mock<ILogger<HomeController>>();
            homeController = new HomeController(mockLogger.Object);
        }

        [Fact]
        void Index()
        {
            var controllerActionResult = homeController.Index();
            Assert.NotNull(controllerActionResult);

        }

        [Fact]
        void Privacy()
        {
            var controllerActionResult = homeController.Privacy();
            Assert.NotNull(controllerActionResult);
        }

    }
}
