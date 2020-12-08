using DTO.Enums;
using DTO.Request;
using Infrastructure.Validation;
using NUnit.Framework;
using PingerApp.Tests.Helpers;
using System.Net;

namespace PingerApp.Tests.HostValidatorTests
{
    public class PortValidationTest
    {
        private HostValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new HostValidator();
        }

        [Test]
        public void Test_NotValidWhenPortIsNotExist()
        {
            // Arrange
            var host = HostValidatorHelper.GetValidRequestDto();
            host.Port = -10;

            // Assert
            Assert.IsFalse(_validator.Validate(host).IsValid);
        }
    }
}