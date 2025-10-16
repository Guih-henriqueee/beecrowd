// Exercício Beecrowd 1001
using System;

namespace Bee1001
{
    public class ExtremamenteBasico
    {

        public int ValueA { get; private set; }
        public int ValueB { get; private set; }
        public int ValueX { get; private set; }

        public ExtremamenteBasico(int valueA, int valueB)
        {
            ValueA = valueA;
            ValueB = valueB;

            FindXValue();
        }

        private void FindXValue()
        {
            ValueX = ValueA + ValueB;
        }

        public int GetValueX()
        {
            return ValueX;
        }

    }

    class Program
    {
        static void Main()
        {
            int valueA = int.Parse(Console.ReadLine());
            int valueB = int.Parse(Console.ReadLine());

            ExtremamenteBasico Find = new ExtremamenteBasico(valueA, valueB);
            Console.WriteLine($"X = {Find.GetValueX()}");
        
        }

    }
}