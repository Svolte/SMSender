using System.IO;
using System.Linq;
using System.Reflection;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using Xunit;
using Xunit.Abstractions;

namespace SMSender.Tests
{
    public class AntonTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AntonTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestReadFile()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"Tests\test.xlsx");
            using var stream = File.OpenRead(filePath);
            var workbook = WorkbookFactory.Create(stream);
            var data = new Mapper(workbook).Take<dynamic>().ToList();
            var firstRow = data.FirstOrDefault();
            foreach (var prop in firstRow.Value.GetType().GetProperties())
            {
                _testOutputHelper.WriteLine($"{prop.Name} = {prop.GetValue(firstRow.Value)}");
            }
        }
    }
}