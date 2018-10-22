using Mingle.Internal.Duktape;
using System;
using System.Runtime.InteropServices;

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
                CompilationFlags.DUK_COMPILE_STRLEN | CompilationFlags.DUK_COMPILE_NOFILENAME |
                CompilationFlags.DUK_COMPILE_SAFE;

            if (NativeMethods.duk_eval_raw(_dukContext, source, (ulong)source.Length, (uint)compilationFlags) != 0)
            {
                var error = Marshal.PtrToStringAnsi(NativeMethods.duk_safe_to_lstring(_dukContext, -1, IntPtr.Zero));
            }
            var result = NativeMethods.duk_get_int(_dukContext, -1);

            return true;
        }
    }
}
