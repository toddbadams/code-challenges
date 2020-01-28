using FluentAssertions;
using TimeToSpeech.Application;
using Xunit;

namespace TimeToSpeech.Tests
{

    public class WrittenTimeProcessorTest
    {
        private readonly WrittenTimeProcessor _processor;

        public WrittenTimeProcessorTest()
        {
            _processor = new WrittenTimeProcessor();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("240 0")]
        [InlineData("fred")]
        [InlineData("2500")]
        [InlineData("25:00")]
        [InlineData("0060")]
        [InlineData("24:01")]
        public void Process_Should_Return_Invalid_When_Time_Is_Not_Well_Formed(string time)
        {
            _processor.Process(time).Should().Be("Invalid format, should be [hh][mm] or [hh]:[mm]");
        }

        [Theory]
        [InlineData("00:00", "Midnight")]
        [InlineData("24:00", "Midnight")]
        [InlineData("00:30", "Half past midnight")]
        [InlineData("001", "One past midnight")]
        [InlineData("12:00", "Noon")]
        [InlineData("1200", "Noon")]
        [InlineData("11:31", "Twenty nine to noon")]
        [InlineData("12:03", "Three past noon")]
        [InlineData("1:00", "One o'clock")]
        [InlineData("01:00", "One o'clock")]
        [InlineData("2:00", "Two o'clock")]
        [InlineData("13:00", "One o'clock")]
        [InlineData("13:05", "Five past one")]
        [InlineData("13:10", "Ten past one")]
        [InlineData("13:21", "Twenty one past one")]
        [InlineData("13:22", "Twenty two past one")]
        [InlineData("13:23", "Twenty three past one")]
        [InlineData("13:24", "Twenty four past one")]
        [InlineData("13:25", "Twenty five past one")]
        [InlineData("13:26", "Twenty six past one")]
        [InlineData("13:27", "Twenty seven past one")]
        [InlineData("13:28", "Twenty eight past one")]
        [InlineData("13:29", "Twenty nine past one")]
        [InlineData("13:30", "Half past one")]
        [InlineData("13:35", "Twenty five to two")]
        [InlineData("13:55", "Five to two")]
        [InlineData("23:55", "Five to midnight")]
        public void Process_Should_Return_Valid_Time_When_Time_Is_Well_Formed(string time, string expected)
        {
            _processor.Process(time).Should().Be(expected);
        }
    }
}
