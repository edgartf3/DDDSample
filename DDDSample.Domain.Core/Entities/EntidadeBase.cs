using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Entities
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            this.Ativo = true;
        }
        
        public Guid Id { get; set; }
        public DateTime? CriadoEm { get; set; }

        public bool Ativo { get; set; }
    }
    
}
