using PowerfulSpace.Facts.Web.Infrastructure.Mappers.Base;
using Xunit;

namespace PowerfulSpace.Facts.Web.Tests
{
    public class AutomapperTests
    {
        [Fact]
        [Trait("Automapper", "Mapper Configuration")]
        public void ItShouldCorrectlyConfigured()
        {
            var config = MapperRegistration.GetMapperConfiguration();

            config.AssertConfigurationIsValid();
        }
    }
}
