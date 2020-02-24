using System;
using System.IO;
using System.Text;

namespace StreamsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stream = File.OpenRead("content.txt");
            byte[] buffer = new byte[8192];
            Span<byte> span = buffer.AsSpan();
            int read = stream.Read(span);
            var span1 = span.Slice(0, read);
            string s = Encoding.UTF8.GetString(span1);
           
            Console.WriteLine(s);
        }
    }
}
