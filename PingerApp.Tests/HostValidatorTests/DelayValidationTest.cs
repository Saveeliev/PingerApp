using Infrastructure.Validation;
using NUnit.Framework;
using PingerApp.Tests.Helpers;

namespace PingerApp.Tests.HostValidatorTests
{
    public class DelayValidationTest
    {
        private HostValidatior _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new HostValidatior();
        }

        [Test]
        public void Test_NotValidWhenDelayIsNegative()
        {
            // Arrange
            var host = HostValidatorHelper.GetValidRequestDto();
            host.DelayInMilliseconds = -10;

            // Assert
            Assert.IsFalse(_validator.Validate(host).IsValid);
        }
    }
}
