using System;

namespace ALibrary
{
    public interface IAnInterface
    {
        void Display();
        public void Display2()
        {
            Console.WriteLine("Display2");
        }

        public static void Foo() => Console.WriteLine("Foo");
    }
}
