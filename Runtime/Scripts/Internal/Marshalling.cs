using System;
using System.Runtime.InteropServices;

namespace Unity.WebRTC
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct OptionalInt
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool hasValue;
        public int value;

        public static implicit operator int?(OptionalInt a)
        {
            return a.hasValue ? a.value : (int?)null;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct OptionalUlong
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool hasValue;
        public ulong value;

        public static implicit operator ulong?(OptionalUlong a)
        {
            return a.hasValue ? a.value : (ulong?)null;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct OptionalUint
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool hasValue;
        public uint value;

        public static implicit operator uint?(OptionalUint a)
        {
            return a.hasValue ? a.value : (uint?)null;
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

        public void Set(T[] array)
        {
            length = array.Length;
            ptr = IntPtrExtension.ToPtr(array);
        }
    }
}
