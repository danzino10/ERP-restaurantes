using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Money.modelos
{
    class Produto
    {
        private int Id;
        private string Nome;
        private string Disponibilidade;
        private float Preco;
        public Produto(int id, string nome, string disponibilidade, float preco)
        {
            Id = id;
            Nome = nome;
            Disponibilidade = disponibilidade;
            Preco = preco;
        }
    }
}
