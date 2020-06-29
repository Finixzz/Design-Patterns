using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SingletonDemo
{
    public sealed class Singleton
    {

        private static Singleton _instance;
        private static int _instanceCounter { get; set; }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

        private Singleton()
        {
            Console.WriteLine("Number of instantiated objects: "+(++_instanceCounter));
        }
        
        public void printMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        
    }
}
