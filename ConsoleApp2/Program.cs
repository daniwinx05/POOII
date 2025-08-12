using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta cc01 = new Conta(100, 1, 100);
            Cliente cl01 = new Cliente("Dani", "123", "Cariacica");

            cc01.Corrente = cl01;

            Console.WriteLine($"Saldo: {cc01.saldo}");
            cc01.Depositar(200);
            Console.WriteLine($"Saldo: {cc01.saldo}");

        }
    }
}
