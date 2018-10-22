using Mingle;
using Xunit;

namespace MIingle.Tests
{
    public class JSContextTests
    {
        [Fact]
        public void Can_create_JSContext()
        {
            using (var context = new JSContext())
            {
                context.Evaluate("1+");
            }
        }
    }
}
