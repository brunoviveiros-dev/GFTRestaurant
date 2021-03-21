using GFTRestaurant.API;
using GFTRestaurant.Domain.Interfaces.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace GFTRestaurant.Tests
{
    public class OrdersTest
    {
        private DependencyResolver _serviceProvider;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
            var webHost = WebHost.CreateDefaultBuilder()
                            .UseStartup<Startup>()
                            .UseConfiguration(configuration)
                            .Build();
            _serviceProvider = new DependencyResolver(webHost);
        }

        #region "MORNING-TESTS"

        [Test]
        public void CreateOrder_Morning_EggsToastCoffe([Values("morning,1,2,3", "morning,2,1,3","morning,3,2,1")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("eggs,toast,coffee", order.Detail);
        }

        [Test]
        public void CreateOrder_Morning_EggsToastCoffe3x([Values("morning,1,2,3,3,3", "morning,3,2,3,1,3", "morning,3,3,3,2,1")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("eggs,toast,coffee(x3)", order.Detail);
        }

        [Test]
        public void CreateOrder_Morning_EggsToastCoffeError([Values("morning,1,2,3,4", "morning,1,2,3,5")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("eggs,toast,coffee,error", order.Detail);
        }

        #endregion

        #region "NIGHT-TESTS"

        [Test]
        public void CreateOrder_Night_SteakPotatoWineCake([Values("night,1,2,3,4", "night,1,3,2,4", "night,4,3,2,1")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("steak,potato,wine,cake", order.Detail);
        }

        [Test]
        public void CreateOrder_Night_SteakPotatox2Cake([Values("night,1,2,2,4", "night,1,4,2,2", "night,2,1,2,4")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("steak,potato(x2),cake", order.Detail);
        }

        [Test]
        public void CreateOrder_Night_SteakError([Values("night,1,1,2,3,5", "night,1,9")] string orderInput)
        {
            var serviceOrder = _serviceProvider.GetService<IServiceOrder>();
            var order = serviceOrder.CreateAnOrder(orderInput);
            Assert.AreEqual("steak,error", order.Detail);
        }

        #endregion

    }
}