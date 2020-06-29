using System;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            s1.printMessage("Hello");

            Singleton s2 = Singleton.Instance;
            s2.printMessage("Singleton");

        }
    }
}
