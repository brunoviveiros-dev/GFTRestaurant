using AutoMapper;
using GFTRestaurant.App.Mappers;
using NUnit.Framework;

namespace GFTRestaurant.Tests
{
    public class MappingTest
    {
        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var mapperConfig = new MapperConfiguration(m => { m.AddProfile(new MappingProfile()); });
            mapperConfig.AssertConfigurationIsValid();
        }
    }
}
