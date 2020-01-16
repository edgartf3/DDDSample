using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Cliente: EntidadeBase, ICliente
    {        

        public string Nome { get; set; }
        
        public IEndereco Faturamento { get; set; }

        public override bool IsValid()
        {
            return true;            
        }
    }
}
