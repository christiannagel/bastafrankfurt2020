using ALibrary;
using System;

namespace DefaultInterfaceMethods
{
    class MyClass : IAnInterface
    {
        public void Display() => Console.WriteLine("Display");
        public void Bar() => IAnInterface.Foo();

        public void DoSomething()
        {
            (this as IAnInterface).Display2();
        }
    }
}
