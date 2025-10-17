// Exercício Beecrowd 1012
using System;
using System.Collections.Generic;

namespace Bee1012
{
    public class Area
    {
        public double Altura { get; private set; }
        public double Largura { get; private set; }
        public double Profundidade { get; private set; }
        public double Pi { get; private set; } = 3.14159f;
        public double Volume { get; private set; }

        public double CalcularTrianguloResultado { get; private set; }
        public double CalcularCirculoResultado { get; private set; }
        public double CalcularTrapezioResultado { get; private set; }
        public double CalcularQuadradoResultado { get; private set; }
        public double CalcularRetanguloResultado { get; private set; }

        public Area(double _Altura, double _Largura, double _Profundidade)
        {
            Altura = _Altura;
            Largura = _Largura;
            Profundidade = _Profundidade;

            CalcularTriangulo();
            CalcularCirculo();
            CalcularTrapezio();
            CalcularQuadrado();
            CalcularRetangulo();
        }

        private void CalcularTriangulo()
        {
            Volume = (Altura * Profundidade) / 2;
            CalcularTrianguloResultado = Volume;
        }
        private void CalcularCirculo()
        {
            Volume = (Profundidade * Profundidade) * Pi;
            CalcularCirculoResultado = Volume;
        }
        private void CalcularTrapezio()
        {
            Volume = ((Altura + Largura) * Profundidade) / 2;
            CalcularTrapezioResultado = Volume;
        }
        private void CalcularQuadrado()
        {
            Volume = Largura * Largura;
            CalcularQuadradoResultado = Volume;
        }
        private void CalcularRetangulo()
        {
            Volume = Altura * Largura;
            CalcularRetanguloResultado = Volume;
        }

        public double GetCalcularTriangulo()
        {
            return CalcularTrianguloResultado;
        }
        public double GetCalcularCirculo()
        {
            return CalcularCirculoResultado;
        }
        public double GetCalcularTrapezio()
        {
            return CalcularTrapezioResultado;
        }
        public double GetCalcularQuadrado()
        {
            return CalcularQuadradoResultado;
        }
        public double GetCalcularRetangulo()
        {
            return CalcularRetanguloResultado;
        }



    }

    class Program
    {

        static void Main()
        {

            string[] Objeto = Console.ReadLine().Split(' ');
            double _Altura = double.Parse(Objeto[0]);
            double _Largura = double.Parse(Objeto[1]);
            double _Profundidade = double.Parse(Objeto[2]);

            Area _Area = new Area(_Altura, _Largura, _Profundidade);
            Console.WriteLine($"TRIANGULO: {_Area.GetCalcularTriangulo():F3}");
            Console.WriteLine($"CIRCULO: {_Area.GetCalcularCirculo():F3}");
            Console.WriteLine($"TRAPEZIO: {_Area.GetCalcularTrapezio():F3}");
            Console.WriteLine($"QUADRADO: {_Area.GetCalcularQuadrado():F3}");
            Console.WriteLine($"RETANGULO: {_Area.GetCalcularRetangulo():F3}");

        }
    }
    

}