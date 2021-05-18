using System.Threading.Tasks;
using Claytondus.EasyPost.Models;
using Claytondus.PrintNode.Test;
using Xunit;

namespace Claytondus.EasyPost.Tests
{
    public class TrackerTest
    {
        [Fact]
        public async Task CreateTrackerTest()
        {
            var client = new EasyPostClient(Configuration.GetSetting("EasyPostToken"));

            var tracker = await client.CreateTrackerAsync(new Tracker
            {
                tracking_code = "EZ1000000001",
                carrier = "UPS"
            });
            Assert.NotNull(tracker);
        }
    }
}
