using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Configuration;
using SMSender.Services;
using Xunit;
using Xunit.Abstractions;

namespace SMSender.Tests
{
    public class SmsServiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly SmsApi _sut;

        public SmsServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = false });
            var config = InitConfiguration();
            fixture.Register(() => config);
            _sut = fixture.Create<SmsApi>();
        }
        
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .AddEnvironmentVariables() 
                .Build();
            return config;
        }

        [Fact]
        public async Task SendSms_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var phoneNumber = "+46700039001";
            var message = "Hello World!";

            // Act
            await _sut.SendMessageAsync(phoneNumber, message);

            // Assert
            // Assert.True(result);
        }
    }
}