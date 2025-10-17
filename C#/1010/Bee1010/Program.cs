// Exercício Beecrowd 1010
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Bee1010
{

    public class Produto
    {
        public int Quantity { get; private set; }
        public double Value { get; private set; }
        public double TotalSell { get; private set; }
        public Produto(int _Quantity, double _Value)
        {
            Quantity = _Quantity;
            Value = _Value;

            SetTotalSell();
        }

        private void SetTotalSell()
        {
            TotalSell = Value * Quantity;
        }


        public double GetTotalSell()
        {
            return TotalSell;
        }
    }

    class Program
    {
        static void Main()
        {
            double TotalBuy = 0.0f;     
            Dictionary<int, Produto> Sells = new Dictionary<int, Produto>();
            int n = 2;

            for (int i = 0; i < n; i++)
            {
                string[] Cart = Console.ReadLine().Split(' ');
                int _Id = int.Parse(Cart[0]);
                int _Quantity = int.Parse(Cart[1]);
                double _Value = double.Parse(Cart[2]);

                Produto Sell = new Produto(_Quantity, _Value);
                Sells[_Id] = Sell;
            }

            foreach (KeyValuePair<int, Produto> par in Sells)
            {
                Produto Sell = par.Value;
                double TotalProduto = Sell.GetTotalSell();
                TotalBuy += Total;

                
            }
            Console.WriteLine($"VALOR A PAGAR: R$ {TotalBuy:F2}");

            
        }
    }

}