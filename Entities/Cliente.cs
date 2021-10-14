using System;
using System.Collections.Generic;

namespace APInet5
{
    public class Cliente
    {
        public Cliente(string nome, string nascimento, string email){
            Id = Guid.NewGuid();
            Nome = nome;
            Nascimento = nascimento;
            Email = email;
        }

        public Guid Id { get; set;}
        public string Nome { get; set; }

        public string Nascimento  {get; set; }

        public string Email { get; set; }

        //public static List<Cliente> Clientes = new List<Cliente>();
    }
}
