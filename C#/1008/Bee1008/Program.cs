using System;
using System.Collections.Generic;

// Classe que representa um funcionário
public class Funcionario
{
    // Propriedades do funcionário
    public int HorasTrabalhadas { get; set; }
    public double ValorHora { get; set; }

    // Construtor para inicializar os dados do funcionário
    public Funcionario(int horasTrabalhadas, double valorHora)
    {
        HorasTrabalhadas = horasTrabalhadas;
        ValorHora = valorHora;
    }

    // Método para calcular o salário do funcionário
    public double CalcularSalario()
    {
        return HorasTrabalhadas * ValorHora;
    }
}

class Program
{
    static void Main()
    {
        // Dicionário para armazenar os funcionários
        // Chave = número do funcionário
        // Valor = objeto Funcionario
        Dictionary<int, Funcionario> funcionarios = new Dictionary<int, Funcionario>();

        // Número de funcionários que vamos processar
        int n = int.Parse(Console.ReadLine());

        // Loop para ler os dados de cada funcionário
        for (int i = 0; i < n; i++)
        {
            // Leitura do número do funcionário
            int numero = int.Parse(Console.ReadLine());

            // Leitura das horas trabalhadas
            int horasTrabalhadas = int.Parse(Console.ReadLine());

            // Leitura do valor por hora
            double valorHora = double.Parse(Console.ReadLine());

            // Cria um objeto Funcionario com os dados lidos
            Funcionario funcionario = new Funcionario(horasTrabalhadas, valorHora);

            // Adiciona o funcionário no dicionário
            funcionarios[numero] = funcionario;
        }

        // Processa e exibe o salário de cada funcionário
        foreach (KeyValuePair<int, Funcionario> par in funcionarios)
        {
            int numeroFuncionario = par.Key;
            Funcionario funcionario = par.Value;

            double salario = funcionario.CalcularSalario();

            Console.WriteLine($"NUMBER = {numeroFuncionario}");
            Console.WriteLine($"SALARY = U$ {salario:F2}");
        }
    }
}
