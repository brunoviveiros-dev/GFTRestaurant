using GFTRestaurant.Domain.Enumerators;
using NUnit.Framework;
using System;

namespace GFTRestaurant.Tests
{
    public class OrdersTest
    {
        [Test]
        public void PlaceOrderMorningEggsToastCoffe([Values("morning,1,2,3","morning,2,1,3")] string order)
        {
        }

        [Test]
        public void PlaceOrderNightSteakPotatoWineCake([Values("night,1,2,3,4", "night,2,1,4,3")] string order)
        {
            var orderSteps = order.Split(",");
            Array.Sort(orderSteps);

            var oderOutput = String.Empty;
            for (int i = 0; i < orderSteps.Length - 1; i++)
            {
                oderOutput += (eDishMorning)Convert.ToInt32(orderSteps[i]) + ",";
            }

            Assert.IsFalse(orderSteps[orderSteps.Length - 1].ToUpper() != "NIGHT");
        }
    }
}