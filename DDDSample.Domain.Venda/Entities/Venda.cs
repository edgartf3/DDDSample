using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Venda: EntidadeBase
    {        
        public int Numero { get; set; }
        public DateTime Data { get; set; }                
        public Cliente Cliente { get; set; }        
        public double ValorMercadoria { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorTotal { get; set; }
        public List<Item> Itens { get; set; }
        public IEndereco Entrega { get; set; }

    }
}
