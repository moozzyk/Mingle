using Mingle.Internal.Duktape;
using System;

namespace Mingle
{
    public class JSContext : IDisposable
    {
        private readonly IntPtr _dukContext;

        public JSContext()
        {
            _dukContext = Duktape.CreateHeap();
        }

        public void Dispose()
        {
            Duktape.DestroyHeap(_dukContext);
        }

        public int EvaluateInt(string source)
        {

            if (!Duktape.Evaluate(_dukContext, source))
            {
                throw new InvalidOperationException(Duktape.CoerceToString(_dukContext));
            }

            return Duktape.GetResultInt(_dukContext);
        }
    }
}
