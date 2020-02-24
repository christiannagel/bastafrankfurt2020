using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AlternativeExtensionMethod
{
    public interface IEnumerableEx<T> : IEnumerable<T>
    {
        public IEnumerable<T> Where(Func<T, bool> pred)
        {
            foreach (var item in this)
            {
                if (pred(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class MyCollection<T> : Collection<T>, IEnumerableEx<T>
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var coll = new MyCollection<string>() { "James", "Jack", "Niki", "Jochen", "Sebastian", "Lewis", "Juan" };
            var jRacers = GetJRacers(coll);
            foreach (var r in jRacers)
            {
                Console.WriteLine(r);
            }
            
        }

        static IEnumerable<string> GetJRacers(IEnumerableEx<string> racers)
        {
            return racers.Where(r => r.StartsWith("J"));
        }
    }
}
