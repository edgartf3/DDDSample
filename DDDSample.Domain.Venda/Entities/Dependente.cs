using DDDSample.Domain.Core.Attributes;
using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class Dependente: EntidadeBase
    {
        public Dependente(string nome)
        {
            this.Nome = nome;
        }
        public string Nome { get; set; }
        public string CPF { get; set; }

        [NotPersist]
        public virtual Pessoa Pessoa { get; set; }
        
        public Guid PessoaId { get; set; }

    }
}
