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
    }
}
