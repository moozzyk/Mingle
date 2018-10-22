using System;
using System.Runtime.InteropServices;

namespace Mingle.Internal.Duktape
{
    public class NativeMethods
    {
        [DllImport("duktape")]
        public static extern IntPtr duk_create_heap(IntPtr alloc_func, IntPtr realloc_func, IntPtr free_func,
            IntPtr heap_udata, IntPtr fatal_handler);

        [DllImport("duktape")]
        public static extern IntPtr duk_destroy_heap(IntPtr ctx);
    }
}