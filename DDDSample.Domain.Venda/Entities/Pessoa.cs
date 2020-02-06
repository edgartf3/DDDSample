using DDDSample.Domain.Core.Attributes;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Entities;
using DDDSample.Domain.ValuesObject;
using System;
using System.Collections.Generic;

namespace DDDSample.Domain.Entities
{
    public class Pessoa: EntidadeBase
    {
        
        public Pessoa()
        {
            this.Dependentes = new HashSet<Dependente>();            
        }


        public string Nome { get; set; }
        public string Cpf_CNPJ { get; set; }
        
        public Endereco Faturamento { get; set; }

        public Endereco Entrega { get; set; }
        
        public ICollection<Dependente> Dependentes { get; set; }


        public CaracteristicaFisica CaracteristicasFisica { get; set; }
        
        
        public Guid RamoAtividadeId { get; set; }

        [NotPersist]
        public virtual RamoAtividade RamoAtividade { get; set; }

        

    }
}
