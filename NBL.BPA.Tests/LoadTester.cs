using NBL.BPA.DataLoader;
using Xunit;

namespace NBL.BPA.Tests
{
    public class LoadTester
    {
        [Fact]
        public void loadata()
        {
           Processor processor = new Processor();
            processor.LoadData(@"C:\\csv");
            Assert.True(false);
        }

    }
}