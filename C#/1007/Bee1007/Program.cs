using System;
using System.Collections.Generic;

public class Variaveis
{
    // Dicionário para armazenar cada variável com sua chave e valor
    private Dictionary<string, int> valores;

    // Construtor: inicializa o dicionário vazio
    public Variaveis()
    {
        valores = new Dictionary<string, int>();
    }

    // Adiciona ou atualiza um valor no dicionário
    public void Adicionar(string chave, int valor)
    {
        valores[chave] = valor;
    }

    // Obtém o valor de uma variável pelo nome
    public int ObterValor(string chave)
    {
        return valores.ContainsKey(chave) ? valores[chave] : 0;
    }

    // Calcula a diferença conforme o problema 1007: (A*B - C*D)
    public int CalcularDiferenca()
    {
        int a = ObterValor("A");
        int b = ObterValor("B");
        int c = ObterValor("C");
        int d = ObterValor("D");

        return (a * b) - (c * d);
    }

    // Método auxiliar para exibir todos os valores (opcional)
    public void MostrarValores()
    {
        foreach (var par in valores)
        {
            Console.WriteLine($"{par.Key} = {par.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Cria o objeto que vai gerenciar as variáveis
        Variaveis variaveis = new Variaveis();

        // Array com as chaves que vamos ler
        string[] chaves = { "A", "B", "C", "D" };

        // Loop de leitura
        foreach (var chave in chaves)
        {
            int valor = int.Parse(Console.ReadLine());
            variaveis.Adicionar(chave, valor); // Armazena no objeto
        }

        // Calcula a diferença usando o método da classe
        int resultado = variaveis.CalcularDiferenca();

        // Exibe a saída conforme o enunciado do problema
        Console.WriteLine($"DIFERENCA = {resultado}");
    }
}
