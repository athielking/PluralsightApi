using Microsoft.AspNetCore.Mvc;
using Moq;
using PluralsightApi.Web.Controllers;
using PluralsightApi.Web.Models;
using PluralsightApi.Web.Services;

namespace PluralsightApi.Tests
{
    public class InventoryControllerTests
    {
        [Fact]
        public void GetWithValidID_Returns_200WithJson()
        {
            var mockService = new Mock<IInventoryService>();
            mockService
                .Setup(service => service.GetLocationInventory(It.IsAny<int>()))
                .Returns((int id) => new LocationInventory
                {
                    Id = id,
                    LocationName = "Main Street",
                    KgDarkRoast = 5.8m,
                    KgLightRoast = 10.0m,
                    KgMediumRoast = 7.5m,
                    KgSeasonalRoast = 0.0m
                }
            );

            var controller = new InventoryController(mockService.Object);
            var result = controller.GetById(1);

            Assert.IsType<ActionResult<LocationInventory>>(result);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void GetWithInvalidID_Returns_NotFound()
        {
            var mockService = new Mock<IInventoryService>();
            mockService
                .Setup(service => service.GetLocationInventory(It.IsAny<int>()))
                .Returns((int id) => null);

            var controller = new InventoryController(mockService.Object);
            var result = controller.GetById(-1);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
