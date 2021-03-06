using DTO.Enums;
using DTO.Request;
using Infrastructure.Request;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace PingerApp.Tests
{
    public class GetHttpResponseTest
    {
        private HttpRequest _request;
        

        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<ILogger<HttpRequest>>();
            _request = new HttpRequest(mock.Object);
        }

        [Test]
        public void Test_ExpectedExceptionWhenRequestIsNull()
        {
            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _request.GetResponseAsync(null));
        }

        [Test]
        public async Task Test_GoodRequest()
        {
            // Act
            var result = await _request.GetResponseAsync(GetRequestDto());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Date);
            Assert.IsNotNull(result.Host);
            Assert.IsNotNull(result.Status);
        }

        private RequestDto GetRequestDto()
        {
            return new RequestDto()
            {
                Host = "ya.ru",
                Port = 80,
                ProtocolType = ProtocolType.Http,
                DelayInMilliseconds = 2000
            };
        }
    }
}