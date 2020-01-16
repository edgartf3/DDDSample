using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Produto: EntidadeBase, IProduto
    {
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
