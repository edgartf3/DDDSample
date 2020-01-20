using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Produto : EntidadeBase, IAutoValida
    {              
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public bool IsValid()
        {            
            return ((this.Preco > 0) && (this.Descricao != ""));
        }
        
    }
}
