using DDDSample.Domain.Attributes;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
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
        
        [Edgar("ASKFHSD")]
        public Guid RamoAtividadeId { get; set; }
        public virtual RamoAtividade RamoAtividade { get; set; }


    }
}
