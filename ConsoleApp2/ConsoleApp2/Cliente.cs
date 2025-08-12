using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Cliente
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }

        public Cliente(string nome, string cpf, string endereco) 
        {
            nome = nome ?? throw new ArgumentNullException(nameof(nome));
            cpf = cpf ?? throw new ArgumentNullException( nameof(cpf));
            endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        }

        
    }
}
