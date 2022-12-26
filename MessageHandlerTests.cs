using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;
using Xunit.Abstractions;

namespace SMSender
{
    public class MessageHandlerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MessageHandler _sut;

        public MessageHandlerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            _sut = fixture.Create<MessageHandler>();
        }

        [Fact]
        public async Task SendMessage_ReturnsCorrectlyFormattedString()
        {
            var expectedResult = "Hej Anton";
            var result = await _sut.SendMessage(@"Hej {{name}}",
                new Dictionary<string, object> { { "name", "Anton" } });
            _testOutputHelper.WriteLine(result);
            Assert.True(expectedResult == result);
        }
    }
}