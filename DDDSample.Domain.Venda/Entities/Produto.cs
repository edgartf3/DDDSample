using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;

namespace DDDSample.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {

        }

        public Produto(string descricao, double preco)
        {
            Descricao = descricao;
            Preco = preco;
            Ativo = true;
        }

        public string Descricao { get; set; }
        public double Preco { get; set; }

        public bool Ativo { get; set; }

        public Guid? FabricanteId { get; set; }
        public virtual Fabricante Fabricante { get; set; }

        public bool IsValid()
        {            
            return ((this.Preco > 0) && (this.Descricao != ""));
        }
        
    }
}
