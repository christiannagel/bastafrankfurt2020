using System;
using System.Linq;

namespace RangesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RangesWithStrings();
            RangesWithArrays();
            IndexSample();
            RangeSample();
            ImmutableSample();
            MutableSample();
            ListSample();
            CustomCollections();

            Console.WriteLine();
        }

        private static void RangesWithStrings()
        {
            string helloWorld = "Hello, World!";
            string world = helloWorld.Substring(startIndex: 7, length: 5);
            Console.WriteLine(world);
            string world1 = helloWorld[7..^1];
            Console.WriteLine(world1);
        }

        private static void RangesWithArrays()
        {
            string[] names = { "James", "Niki", "Jochen", "Juan", "Michael", "Sebastian", "Nino", "Lewis" };

            var lewis = names[^1];
            Console.WriteLine(lewis);
            foreach (var name in names[2..^2])  // Jochen, Juan, Michael, Sebastian
            {
                Console.WriteLine(name);
            }
        }

        private static void IndexSample()
        {
            var data = Enumerable.Range(0, 10).ToArray();
            Index index1 = 3;
            var index2 = ^1;

            Console.WriteLine($"{index1}: {data[index1]}");
            Console.WriteLine($"{index2}: {data[index2]}");
        }

        private static void RangeSample()
        {
            var data = Enumerable.Range(0, 10).ToArray();
            Range range1 = 4..9;
            Console.WriteLine($"Start: {range1.Start}");
            Console.WriteLine($"End: {range1.End}");

            foreach (var item in data[range1])
            {
                Console.Write($"{item} ");  // 4 5 6 7 8
            }
            Console.WriteLine();

            string fox1 = "the quick brown fox jumped over the lazy dogs";
            string quick = fox1[4..9];  // inkl. to excl.
            string dog = fox1[^4..^1];
            string brownfoxjumped = fox1[10..];
            string thequick = fox1[..9];
            string fox2 = fox1[..];
        }

        private static void ImmutableSample()
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8 };
            var range = data[2..^2];

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = 42;
            }

            int result = data.Sum();

            Console.WriteLine($"array didn't change - result: {result}");
        }

        private static void MutableSample()
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8 };
            var range = data.AsSpan()[2..^2];

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = 42;
            }

            int result = data.Sum();

            Console.WriteLine($"array did change - result: {result}");
        }

        private static void ListSample()
        {
            Console.WriteLine(nameof(ListSample));
            var list = Enumerable.Range(0, 100).ToList();
            var item = list[^20];
            Console.WriteLine(item);

            foreach (var i in list.Range(5..30))
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        private static void CustomCollections()
        {
            Console.WriteLine(nameof(CustomCollections));

            var coll = new MyCollection();
            var slice = coll[20..^55];
            foreach (var item in slice)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
