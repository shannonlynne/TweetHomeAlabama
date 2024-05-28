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
            var actualResult = ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result)?.Value;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

       
    }
}