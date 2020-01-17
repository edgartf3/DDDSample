using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Item: EntidadeBase, IItem
    {
        public IProduto Produto { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double SubTotal { get; set; }
        public double ValorDesconto { get; set; }
        public double Total { get; set; }

        //public override bool IsValid()
        //{
        //    return true;
        //}
    }
}
