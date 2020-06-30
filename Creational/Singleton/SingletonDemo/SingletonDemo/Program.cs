using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        public static  void printHello()
        {
            Singleton s1 = Singleton.Instance;
            s1.printMessage("Hello");
        }

        public static void printSingleton()
        {
            Singleton s2 = Singleton.Instance;
            s2.printMessage("Singleton");
        }
        static void Main(string[] args)
        {

            Parallel.Invoke(() => printHello(),
                            () => printSingleton());
        }
    }
}
