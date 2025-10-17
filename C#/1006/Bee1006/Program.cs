// Exercício Beecrowd 1005
using System;
using System.Runtime.CompilerServices;

namespace Bee1005
{

    public class Media2
    {

        public double ValueA { get; private set; }
        public double ValueB { get; private set; }
        public double ValueC { get; private set; }
        public double ValueAPound { get; private set; } = 2.0f;
        public double ValueBPound { get; private set; } = 3.0f;
        public double ValueCPound { get; private set; } = 5.0f;
        public double Result { get; private set; }
        public string _Media { get; private set; } = "MEDIA";

        public Media2(double valueA, double valueB, double valueC)
        {
            ValueA = valueA;
            ValueB = valueB;
            ValueC = valueC;

            Calcular();
        }

        private void Calcular()
        {
            Result = (ValueA * ValueAPound) + (ValueB * ValueBPound) +(ValueC * ValueCPound);
            Result = Result / ( ValueBPound + ValueAPound + ValueCPound);
        }

        public double GetMedia()
        {
            
            return Result;
        }
        public string GetMediaString()
        {

            return _Media;
        }
    }

    class Program
    {
        
        static void Main()
        {

            double valueA = double.Parse(Console.ReadLine());
            double valueB = double.Parse(Console.ReadLine());
            double valueC = double.Parse(Console.ReadLine());

            Media2 Calcular = new Media2(valueA, valueB, valueC);
            Console.WriteLine($"{Calcular.GetMediaString()} = {Calcular.GetMedia().ToString("F1")}");
        }
    }
}