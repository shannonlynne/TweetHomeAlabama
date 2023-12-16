using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Drawing;
using System.Security.Policy;
using System.Xml.Linq;
using TweetHomeAlabama.Application.Model;
using TweetHomeAlabama.Data.Entity;

namespace TweetHomeAlabama.UnitTests
{
    [TestClass]
    public class BirdTest
    {
        private Mock<ITweetHomeAlabamaService> mockService = new Mock<ITweetHomeAlabamaService>();
        private Mock<ILogger<BirdController>> mockLogger = new Mock<ILogger<BirdController>>();

        [TestMethod]
        public async Task AddBird()
        {
            //Arrange
            var birdDto = new BirdDto
            {
                Name = "Flamingo",
                Color = "pink",
                SecondaryColor = "white",
                Habitat = "coast",
                Shape = "tall",
                Size = "large",
                Url = "http://flamingoooooooos",
                Info = "You would love to find one in your pool"
            };

            var expectedResult = new BirdDto
            {
                Name = "Flamingo",
                Color = "pink",
                SecondaryColor = "white",
                Habitat = "coast",
                Shape = "tall",
                Size = "large",
                Url = "http://flamingoooooooos",
                Info = "You would love to find one in your pool"
            };

            mockService.Setup(x => x.AddBird(birdDto))
                .Returns(Task.FromResult(expectedResult));

            //Act
            var controller = new AddBirdController(mockService.Object, mockLogger.Object);
            var actualResult = await controller.PostBird(birdDto);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}