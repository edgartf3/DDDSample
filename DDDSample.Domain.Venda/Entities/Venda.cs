using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Venda: EntidadeBase, IVenda
    {        
        public int Numero { get; set; }
        public DateTime Data { get; set; }                
        public ICliente Cliente { get; set; }        
        public double ValorMercadoria { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorTotal { get; set; }
        public List<IItem> Itens { get; set; }
        public IEndereco Entrega { get; set; }
        //public override bool IsValid()
        //{                
        //    return true;
        //}

    }
}
