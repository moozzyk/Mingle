using System;
using System.Runtime.InteropServices;

namespace Mingle.Internal.Duktape
{
    [Flags]
    public enum CompilationFlags: uint
    {
        DUK_COMPILE_EVAL =          1 << 3,
        DUK_COMPILE_FUNCTION =      1 << 4,
        DUK_COMPILE_STRICT =        1 << 5,
        DUK_COMPILE_SHEBANG =       1 << 6,
        DUK_COMPILE_SAFE =          1 << 7,
        DUK_COMPILE_NORESULT =      1 << 8,
        DUK_COMPILE_NOSOURCE =      1 << 9,
        DUK_COMPILE_STRLEN =        1 << 10,
        DUK_COMPILE_NOFILENAME =    1 << 11,
        DUK_COMPILE_FUNCEXPR =      1 << 12,
    }

    public class NativeMethods
    {
        [DllImport("duktape")]
        public static extern IntPtr duk_create_heap(IntPtr alloc_func, IntPtr realloc_func, IntPtr free_func,
            IntPtr heap_udata, IntPtr fatal_handler);

        [DllImport("duktape")]
        public static extern IntPtr duk_destroy_heap(IntPtr ctx);

        [DllImport("duktape", CharSet = CharSet.Ansi)]
        public static extern uint duk_eval_raw(IntPtr ctx, string src_buffer, ulong src_length, uint flags);

        [DllImport("duktape")]
        public static extern int duk_get_int(IntPtr ctx, int idx);

        [DllImport("duktape")]
        public static extern IntPtr duk_safe_to_lstring(IntPtr ctx, int idx, IntPtr out_len);
    }
}