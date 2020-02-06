using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class Produto : EntidadeBase, IAutoValida
    {
        public Produto()
        {

        }

        public Produto(string descricao, double preco)
        {
            Descricao = descricao;
            Preco = preco;
        }

        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Guid? FabricanteId { get; set; }
        public virtual Fabricante Fabricante { get; set; }

        public bool IsValid()
        {            
            return ((this.Preco > 0) && (this.Descricao != ""));
        }
        
    }
}
