using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Cliente: EntidadeBase
    {        

        public string Nome { get; set; }
        
        public IEndereco Faturamento { get; set; }

    }
}
