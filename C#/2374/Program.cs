using System;

namespace CalibragemPneus
{
    
    public class Calibrador
    {
        
        public int Pressao { get; private set; }
        public int PressaoAtual { get; private set;}
        public int Calibragem { get; private set;}
    
        public Calibrador(int p, int pa )
        {
            Pressao = p;
            PressaoAtual = pa;
            
            CalcularCalibragem();
        }
        
        
        private void CalcularCalibragem()
        {
            Calibragem = PressaoAtual - Pressao;
        }
        
        public int GetCalibragem()
        {
            return Calibragem;
        }
    }
    
    class Program
    {
        
        static void Main()
        {
            int p = int.Parse(Console.ReadLine());
            int pa = int.Parse(Console.ReadLine());
        
            Calibrador pesquisa = new Calibrador(p, pa);
            Console.WriteLine(pesquisa.GetCalibragem());
        }
    }
    
}