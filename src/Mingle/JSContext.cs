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
            Evaluate(source);
            return Duktape.GetBool(_dukContext);
        }

        public double EvaluateNumber(string source)
        {
            Evaluate(source);
            return Duktape.GetNumber(_dukContext);
        }

        public int EvaluateInt(string source)
        {
            Evaluate(source);
            return Duktape.GetInt(_dukContext);
        }

        public uint EvaluateUInt(string source)
        {
            Evaluate(source);
            return Duktape.GetUInt(_dukContext);
        }

        public string EvaluateString(string source)
        {
            Evaluate(source);
            return Duktape.GetString(_dukContext);
        }

        private void Evaluate(string source)
        {
            if (!Duktape.Evaluate(_dukContext, source))
            {
                throw new InvalidOperationException(Duktape.CoerceToString(_dukContext));
            }
        }
    }
}
