using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Pessoa: EntidadeBase
    {


        public string Nome { get; set; }
        public string Cpf_CNPJ { get; set; }

        public Endereco Endereco { get; set; }    
        
        

    }
}
