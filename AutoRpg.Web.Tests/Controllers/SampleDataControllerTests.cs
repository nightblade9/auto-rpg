using AutoRpg.Web.Controllers;
using NUnit.Framework;
using System.Linq;

namespace AutoRpg.Web.Tests.Controllers
{
    [TestFixture]
    public class SampleDataControllerTests
    {
        [Test]
        public void WeatherForecastsReturnsItems()
        {
            var controller = new SampleDataController();
            var actual = controller.WeatherForecasts();
            Assert.That(actual.Any());
        }
    }
}
