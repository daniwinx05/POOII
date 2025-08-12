using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Conta
    {
        public double limite { get; set; }
        public int numero { get; set; }
        public double saldo { get; set; }

        public Cliente Corrente {get; set;}

        public Conta(double limite, int numero, double saldo) {
            this.limite = limite;
            this.numero = numero;
            this.saldo = saldo;
        
        }


        public void Depositar(double valor) => saldo += valor;

        public bool Sacar(double valor) 
        {
            if (saldo > valor) 
            {
                saldo -= valor; 
                return true;
            } 
            return false;
        }

        private bool VerificarTransacao(double valor)
        { 
        
            return saldo > valor;
        }


    }
}
