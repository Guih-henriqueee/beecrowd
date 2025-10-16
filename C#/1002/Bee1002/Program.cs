using System;
using System.Globalization;

namespace Bee1002
{
    public class AreaDoCirculo
    {
        public double Raio { get; private set; }
        public double Area { get; private set; }
        public double Fator { get; private set; }

        public AreaDoCirculo(double raio)
        {
            Raio = raio;
            Fator = 3.14159;
            CalcularArea();
        }

        private void CalcularArea()
        {
            double raioQuadrado = Raio * Raio;
            Area = raioQuadrado * Fator;
        }

        public double GetArea()
        {
            return Area;
        }
    }

    class Program
    {
        static void Main()
        {
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            AreaDoCirculo circulo = new AreaDoCirculo(raio);
            Console.WriteLine($"A={circulo.GetArea().ToString("F4", CultureInfo.InvariantCulture)}");
        }
    }
}
