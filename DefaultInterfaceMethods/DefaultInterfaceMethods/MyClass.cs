using ALibrary;
using System;
using System.Collections.Generic;
using System.Text;

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
