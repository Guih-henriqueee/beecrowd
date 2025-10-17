// Exercício Beecrowd 1005
using System;
using System.Runtime.CompilerServices;

namespace Bee1005
{

    public class Media
    {

        public double ValueA { get; private set; }
        public double ValueB { get; private set; }
        public double ValueAPound { get; private set; } = 3.5f;
        public double ValueBPound { get; private set; } = 7.5f;
        public double Result { get; private set; }
        public string _Media { get; private set; } = "MEDIA";

        public Media(double valueA, double valueB)
        {
            ValueA = valueA;
            ValueB = valueB;

            Calcular();
        }

        private void Calcular()
        {
            Result = (ValueA * ValueAPound) + (ValueB * ValueBPound);
            Result = Result / ( ValueBPound + ValueAPound);
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

            Media Calcular = new Media(valueA, valueB);
            Console.WriteLine($"{Calcular.GetMediaString()} = {Calcular.GetMedia().ToString("F5")}");
        }
    }
}