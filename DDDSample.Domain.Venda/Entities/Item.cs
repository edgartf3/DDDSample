using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Item: EntidadeBase
    {
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double SubTotal { get; set; }
        public double ValorDesconto { get; set; }
        public double Total { get; set; }
    }
}
