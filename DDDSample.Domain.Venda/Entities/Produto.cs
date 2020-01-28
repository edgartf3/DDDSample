using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Produto : EntidadeBase, IAutoValida
    {              
<<<<<<< HEAD
        public string Descricao { get; set; }
        public double Preco { get; set; }
=======
        public string? Descricao { get; set; }
        public double? Preco { get; set; }

        public Guid? FabricanteId { get; set; }
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
        public Fabricante Fabricante { get; set; }

        public bool IsValid()
        {            
            return ((this.Preco > 0) && (this.Descricao != ""));
        }
        
    }
}
