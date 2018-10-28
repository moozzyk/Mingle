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
            if (_dukContext == IntPtr.Zero)
            {
                throw new InvalidOperationException("Unable to create Duktape context");
            }
        }

        public void Dispose() => Duktape.DestroyHeap(_dukContext);

        public bool EvaluateBool(string source)
        {
            if (!Duktape.Evaluate(_dukContext, source))
            {
                throw new InvalidOperationException(Duktape.CoerceToString(_dukContext));
            }

            return Duktape.GetBool(_dukContext);
        }

        public int EvaluateInt(string source)
        {
            if (!Duktape.Evaluate(_dukContext, source))
            {
                throw new InvalidOperationException(Duktape.CoerceToString(_dukContext));
            }

            return Duktape.GetInt(_dukContext);
        }
    }
}
