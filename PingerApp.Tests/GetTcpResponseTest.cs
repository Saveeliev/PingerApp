using DTO.Enums;
using DTO.Request;
using Infrastructure.Request;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace PingerApp.Tests
{
    public class GetTcpResponseTest
    {
        private TcpRequest _request;

        [SetUp]
        public void SetUp()
        {
            _request = new TcpRequest();
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
                ProtocolType = ProtocolType.Tcp,
                DelayInMilliseconds = 2000
            };
        }
    }
}