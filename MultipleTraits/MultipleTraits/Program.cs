using System;

namespace MultipleTraits
{

    public interface IHello
    {
        public void SayHello() => Console.Write("Hello ");
    }

    public interface IWorld
    {
        public void SayWorld() => Console.Write("World");
    }

    public class HelloWorld : IHello, IWorld
    {
        public void SayBang() => Console.WriteLine("!");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var h = new HelloWorld();
            (h as IHello).SayHello();
            (h as IWorld).SayWorld();
            h.SayBang();
        }
    }
}
