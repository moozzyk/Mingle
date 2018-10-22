using Mingle.Internal.Duktape;
using System;

namespace Mingle
{
    public class JSContext : IDisposable
    {
        private readonly IntPtr _dukContext;

        public JSContext()
        {
            _dukContext =
                NativeMethods.duk_create_heap(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }

        public void Dispose()
        {
            NativeMethods.duk_destroy_heap(_dukContext);
        }

        public bool Evaluate(string source)
        {
            var compilationFlags = CompilationFlags.DUK_COMPILE_EVAL | CompilationFlags.DUK_COMPILE_NOSOURCE |
                CompilationFlags.DUK_COMPILE_STRLEN | CompilationFlags.DUK_COMPILE_NOFILENAME;

            NativeMethods.duk_eval_raw(_dukContext, source, (ulong)source.Length, (uint)compilationFlags));
            var result = NativeMethods.duk_get_int(_dukContext, -1);

            return true;
        }
    }
}
