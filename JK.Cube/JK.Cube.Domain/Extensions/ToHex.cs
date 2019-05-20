using System;
using System.Text;

namespace JK.Cube.Domain.Extensions
{
    public static class Extensions
    {
        public static  string ToHex(this string value)
        {
            byte[] ba = Encoding.Default.GetBytes(value);
            return BitConverter.ToString(ba);
        }
    }
}
