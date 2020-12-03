using System;
using System.Runtime.InteropServices;

namespace Unity.WebRTC
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Optional<T> where T : unmanaged
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool hasValue;
        public T value;

        public static implicit operator T?(Optional<T> a)
        {
            T? n = a.hasValue ? a.value : (T?)null;
            return n;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MarshallingArray<T> where T : struct
    {
        public int length;
        public IntPtr ptr;

        public T[] ToArray()
        {
            return ptr.AsArray<T>(length);
        }
    }
}
