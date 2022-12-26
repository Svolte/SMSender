using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using SMSender.Services;
using Xunit;
using Xunit.Abstractions;

namespace SMSender.Tests
{
    public class MessageHandlerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MessageHandler _sut;

        public MessageHandlerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
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

        [Fact]
        public async Task SendMessage_FormatsMessageDynamically()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"Tests\test.xlsx");
            var text =
                @"Hello, {{Name}}. How wonderful that your phone number is {{Phone}}. I also added some additional properties: {{TestProperty1}} {{TestProperty2}}";
            await using var stream = File.OpenRead(filePath);
            var workbook = WorkbookFactory.Create(stream);
            var data = new Mapper(workbook).Take<dynamic>().ToList();
            foreach (var row in data)
            {
                foreach (var prop in row.Value.GetType().GetProperties())
                {
                    _testOutputHelper.WriteLine($"{prop.Name} = {prop.GetValue(row.Value)}");
                }

                var result = await _sut.SendMessage(text, row.ToDictionary());
                _testOutputHelper.WriteLine($"Sent message: {result}");
            }
        }
    }
}