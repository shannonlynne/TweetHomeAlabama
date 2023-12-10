using Castle.Core.Resource;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using TweetHomeAlabama.Application.Service;
using TweetHomeAlabama.Data.Entity;
using TweetHomeAlabama.Data.Repository;
using TweetHomeAlabama.Domain.Model;

namespace TweetHomeAlabama.UnitTests
{
    public class Tests
    {
        Mock<ITweetHomeAlabamaService> MockService;
        List<string> traits = new List<string>();
        List<Bird> birds = new List<Bird>();
        List<BirdEntity> birdEntities = new List<BirdEntity>();
        Bird bird = new Bird();

        [SetUp]
        public void Setup()
        {
            traits = new List<string>
            {
                "large", "tall", "pond", "blue", "grey"
            };

            bird = new Bird("Great Blue Heron", "ImagePath", "Shannon's favorite bird");

            birds = new List<Bird>
            {
                bird
            };

            MockService = new Mock<ITweetHomeAlabamaService>();
        }

        //[Test]
        //public void TestFindBird()
        //{
        //    MockService.Setup(p => p.GetBirds(traits)).ReturnsAsync(birds);

        //    MockService.
        //}

        [TestMethod]
        public void GetCustomerTest()
        {
            const int customerId = 5;

            var birdMock = new Mock<BirdEntity>();

            birdMock.SetupGet(x => x.Color)
            .Returns(bird);

            var mock = new Mock<ITweetHomeAlabamaRepository<BirdEntity>>();

            mock.Setup(x => x.GetBirds())
                .Returns(birdEntities);

            var repository = mock.Object;
            var service = new CustomerService(repository);
            var result = service.GetCustomerById(customerId);

            Assert.AreEqual(customerId, result.CustomerId);
        }
    }
}