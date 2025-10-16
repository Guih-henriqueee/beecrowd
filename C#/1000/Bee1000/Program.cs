// Exercício Beecrowd 1000
using System;

namespace Bee1000
{
    public class HelloWorld
    {
        public string _HelloWorld { get; private set; }

        public HelloWorld()
        {
            SetHelloWorld();
        }

        private void SetHelloWorld()
        {
            _HelloWorld = "Hello World";
        }
        public string GetHelloWorld()
        {
            return _HelloWorld;

        }

    }

    class Program
    {
        
        static void Main()
        {
            HelloWorld Send = new HelloWorld();
            Console.WriteLine($"{Send.GetHelloWorld()}!");
        }
    } 
}