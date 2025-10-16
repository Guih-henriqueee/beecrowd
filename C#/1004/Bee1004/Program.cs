// Exercício Beecrowd 1004

using System;



namespace Bee1004
{

    public class Calculadora
    {

        public int ValueA { get; private set; }
        public int ValueB { get; private set; }
        public int Result { get; private set; }
        public string Operation { get; private set; }

        public Calculadora(int valueA, int valueB)
        {

            ValueA = valueA;
            ValueB = valueB;

            FuncaoProd();

        }


        private void FuncaoProd()
        {
            Operation = "Prod";
            Result = ValueA * ValueB;
        }

        public int GetResult()
        {
            return Result;
        }

        public string GetOperation()
        {
            return Operation;
        }


    }


    class Program
    {
        
        static void Main()
        {
            int valueA = int.Parse(Console.ReadLine());
            int valueB = int.Parse(Console.ReadLine());

            Calculadora Calculo = new Calculadora(valueA, valueB);
            Console.WriteLine($"{Calculo.GetOperation().ToUpper()} = {Calculo.GetResult()}");
        }
    }
}