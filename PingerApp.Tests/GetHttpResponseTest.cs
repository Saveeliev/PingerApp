using DTO;
using DTO.Request;
using DTO.Response;
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
            var result = (HttpResponseDto)_request.GetResponse(GetRequestDto());

            // Assert
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Date);
            Assert.IsNotNull(result.Host);
            Assert.IsNotNull(result.Status);
            Assert.IsNotNull(result.StatusCode);
        }

        private RequestDto GetRequestDto()
        {
            return new RequestDto()
            {
                Host = "ya.ru",
                Port = 80,
                ProtocolType = ProtocolType.http,
                Delay = 2000
            };
        }
    }
}