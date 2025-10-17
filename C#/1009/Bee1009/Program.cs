using System;
using System.Collections.Generic;

namespace KPISeller
{
    // Classe que representa cada vendedor
    public class Vendedores
    {
        public string Vendedor { get; private set; }     // Nome do vendedor
        public double Vendas { get; private set; }       // Total de vendas
        public double SalarioBase { get; private set; }  // Salário base
        public double SalarioFinal { get; private set; } // Salário final com comissão
        private double BonusPorcentagem = 0.15;          // Comissão de 15%

        // Construtor: inicializa os valores e calcula o salário final
        public Vendedores(string vendedor, double salarioBase, double vendas)
        {
            Vendedor = vendedor;
            SalarioBase = salarioBase;
            Vendas = vendas;

            CalcularSalario();
        }

        // Método que calcula o salário final
        public void CalcularSalario()
        {
            SalarioFinal = SalarioBase + (Vendas * BonusPorcentagem);
        }

        // Método para acessar o salário final
        public double GetSalarioFinal()
        {
            return SalarioFinal;
        }
        public string GetVendedor()
        {
            return Vendedor;
        }
    }

    class Program
    {
        static void Main()
        {
            // Dicionário para armazenar os vendedores
            // Chave: ID do vendedor (pode ser incremental)
            // Valor: objeto Vendedores
            Dictionary<int, Vendedores> vendedores = new Dictionary<int, Vendedores>();

            // No Beecrowd 1009, sempre tem 1 vendedor, mas podemos deixar escalável
            int n = 2;

            for (int i = 1; i <= n; i++)
            {
                // Lê o nome do vendedor
                string nome = Console.ReadLine();

                // Lê o salário base
                double salarioBase = double.Parse(Console.ReadLine());

                // Lê o total de vendas
                double vendas = double.Parse(Console.ReadLine());

                // Cria o objeto vendedor
                Vendedores vendedor = new Vendedores(nome, salarioBase, vendas);

                // Armazena no dicionário com a chave i
                vendedores[i] = vendedor;
            }

            // Percorre o dicionário e exibe o salário final de cada vendedor
            foreach (KeyValuePair<int, Vendedores> par in vendedores)
            {        // Pega o objeto vendedor
                Vendedores vendedor = par.Value;             // Pega o objeto vendedor
                string _vendedor = vendedor.GetVendedor();             // Pega o objeto vendedor
                double salario = vendedor.GetSalarioFinal(); // Calcula/obtém o salário final

                // Exibe no formato exigido pelo Beecrowd
                Console.WriteLine($"{_vendedor} - TOTAL = R$ {salario:F2}");
            }
        }
    }
}
