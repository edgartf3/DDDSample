using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class EntidadeBase: IEntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }        
    }
}
