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

            var bird = new BirdDto
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

            var expectedResult = new JsonResult(new { message = "Bird saved successfully" });

            mockService.Setup(x => x.AddBird(birdDto))
                .Returns(Task.FromResult(true));

            //Act
            var controller = new AddBirdController(mockService.Object, mockLogger.Object);
            var actualResult = await controller.PostBird(birdDto);

            //Assert
            Assert.AreEqual(expectedResult.Value?.GetHashCode(), actualResult.Value?.GetHashCode());
        }
    }
}