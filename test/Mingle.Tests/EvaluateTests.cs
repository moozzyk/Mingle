using Mingle;
using System;
using Xunit;

namespace MIingle.Tests
{
    public class EvaluateTest
    {
        public class EvaluateBoolTests: IDisposable
        {
            private JSContext _context = new JSContext();

            [Fact]
            public void EvaluateBool_returns_expected_value() =>
                Assert.True(_context.EvaluateBool("true || false"));

            [Fact]
            public void EvaluateBool_throws_for_invalid_JS() =>
                Assert.Throws<InvalidOperationException>(() => _context.EvaluateBool("true ||"));

            [Fact]
            public void Exceptions_from_EvaluateBool_are_rethrown()
            {
                var exception = Assert.Throws<InvalidOperationException>(
                    () => _context.EvaluateBool("throw new Error('Error occurred.')"));

                Assert.Equal("Error: Error occurred.", exception.Message);
            }

            public void Dispose() => _context.Dispose();
        }

        public class EvaluateNumberTests: IDisposable
        {
            private JSContext _context = new JSContext();

            [Fact]
            public void EvaluateNumber_returns_expected_value() =>
                Assert.Equal(42.0, _context.EvaluateNumber("42.0 + 0.0"));

            [Fact]
            public void EvaluateNumber_throws_for_invalid_JS() =>
                Assert.Throws<InvalidOperationException>(() => _context.EvaluateNumber("42.0 +"));

            [Fact]
            public void Exceptions_from_EvaluateNumber_are_rethrown()
            {
                var exception = Assert.Throws<InvalidOperationException>(
                    () => _context.EvaluateNumber("throw new Error('Error occurred.')"));

                Assert.Equal("Error: Error occurred.", exception.Message);
            }

            public void Dispose() => _context.Dispose();
        }

        public class EvaluateIntTests: IDisposable
        {
            private JSContext _context = new JSContext();

            [Fact]
            public void EvaluateInt_returns_expected_value() =>
                Assert.Equal(42, _context.EvaluateInt("42 + 0"));

            [Fact]
            public void EvaluateInt_throws_for_invalid_JS() =>
                Assert.Throws<InvalidOperationException>(() => _context.EvaluateInt("42 +"));

            [Fact]
            public void Exceptions_from_EvaluateInt_are_rethrown()
            {
                var exception = Assert.Throws<InvalidOperationException>(
                    () => _context.EvaluateInt("throw new Error('Error occurred.')"));

                Assert.Equal("Error: Error occurred.", exception.Message);
            }

            public void Dispose() => _context.Dispose();
        }
    }
}
