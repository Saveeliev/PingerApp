using DTO.Enums;
using DTO.Request;
using Infrastructure.Validation;
using NUnit.Framework;
using PingerApp.Tests.Helpers;
using System.Net;

namespace PingerApp.Tests.HostValidatorTests
{
    public class HostValidationTest
    {
        private HostValidatior _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new HostValidatior();
        }

        [Test]
        public void Test_NotValidWhenHostLengthIsLessThanFive()
        {
            // Arrange
            var host = HostValidatorHelper.GetValidRequestDto();
            host.Host = "o.ru";

            // Assert
            Assert.IsFalse(_validator.Validate(host).IsValid);
        }

        [Test]
        public void Test_NotValidWhenHostIEmpty()
        {
            // Arrange
            var host = HostValidatorHelper.GetValidRequestDto();
            host.Host = "";

            // Assert
            Assert.IsFalse(_validator.Validate(host).IsValid);
        }

        [Test]
        public void Test_NotValidWhenHostIsNotCorrect()
        {
            // Arrange
            var host = HostValidatorHelper.GetValidRequestDto();
            host.Host = "yandexru";

            // Assert
            Assert.IsFalse(_validator.Validate(host).IsValid);
        }
    }
}