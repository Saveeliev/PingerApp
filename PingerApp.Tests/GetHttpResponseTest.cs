using DTO.Enums;
using DTO.Request;
using Infrastructure.Request;
using NUnit.Framework;
using System;

namespace PingerApp.Tests
{
    public class GetHttpResponseTest
    {
        private HttpRequest _request;

        [SetUp]
        public void SetUp()
        {
            _request = new HttpRequest();
        }
        
        [Test]
        public void Test_ExpectedExceptionWhenRequestIsNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _request.GetResponse(null));
        }

        [Test]
        public void Test_GoodRequest()
        {
            var result = _request.GetResponse(GetRequestDto());

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