using Microsoft.AspNetCore.Mvc;

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

            var bird = new Bird("Flamingo", "http://flamingoooooooos", "You would love to find one in your pool");

            var expectedResult = JsonSerializer.Serialize("Bird saved successfully");

            mockService.Setup(x => x.AddBird(birdDto))
                .Returns(Task.FromResult(1));
            
            //Act
            var controller = new BirdController(mockService.Object, mockLogger.Object);
            var result = await controller.AddBird(birdDto);
            var actualResult = (result.Result as CreatedAtActionResult)?.Value;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task SearchBird()
        {
            //Arrange
            var expectedResult = new List<Bird>()
             {
                 new Bird("Silly Bird", "Bird flies in circles all day long", "http://image.com")
             };

            mockService.Setup(x => x.GetBirds(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(expectedResult));
       
            //Act
            var controller = new BirdController(mockService.Object, mockLogger.Object);
            var actualResult = await controller.GetBirds("red", "blue", "small", "long", "wherever");

            //Assert
            Assert.AreEqual(expectedResult, (actualResult.Result as CreatedAtActionResult)?.Value);          
        }

        //test repo layer - integration tests?
    }
}