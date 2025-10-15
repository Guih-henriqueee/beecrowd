// Exercício Beecrowd 1009
using System;

namespace KPISeller
{

    public class Vendedores
    {

        public string Vendedor { get; private set; }
        public double Vendas { get; private set; }
        public double SalarioBase { get; private set; }
        public double SalarioFinal { get; private set; }
        public double BonusPorcentagem = 0.15f;

        public Vendedores(string Seller, double Sales, double Wage)
        {
            Vendedor = Seller;
            Vendas = Sales;
            SalarioBase = Wage;

            CalcularSalario();
        }

        public void CalcularSalario()
        {
            SalarioFinal = Vendas * BonusPorcentagem;
            SalarioFinal += SalarioBase; 
        }

        public double GetSalarioFinal()
        {
            return SalarioFinal;
        }

    }

    class Program
    {
        static void Main()
        {
            string Seller = Console.ReadLine();
            double Wage = double.Parse(Console.ReadLine());
            double Sales = double.Parse(Console.ReadLine());

            Vendedores pesquisa = new Vendedores(Seller, Sales, Wage);
            Console.WriteLine($"TOTAL  = R$ {pesquisa.GetSalarioFinal():F2}");
        }
    }
}