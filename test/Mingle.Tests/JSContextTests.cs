using Mingle;
using System;
using Xunit;

namespace MIingle.Tests
{
    public class JSContextTests : IDisposable
    {
        private JSContext _context = new JSContext();

        [Fact]
        public void EvaluateInt_returns_expected_value()
        {
            Assert.Equal(42, _context.EvaluateInt("42 + 0"));
        }

        [Fact]
        public void EvaluateInt_throws_for_invalid_JS()
        {
            Assert.Throws<InvalidOperationException>(() => _context.EvaluateInt("42 +"));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
