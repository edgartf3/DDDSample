using DDDSample.Domain.Core.Attributes;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDSample.Domain.Entities
{
    public class Venda: EntidadeBase
    {
        private HashSet<Item> _Itens;
        

        public Venda()
        {
            
            this._Itens = new HashSet<Item>();
            this.Numero = 256;            
        }
        public int Numero { get; private set; }
        public DateTime Data { get; set; }                
        public Pessoa Cliente { get; set; }

        [NotPersist]
        public virtual Vendedor Vendedor { get; set; }
        public Guid VendedorId { get; set; }

        public double ValorMercadoria { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorTotal { get; set; }
        public IReadOnlyCollection<Item> Itens { get { return _Itens.ToArray(); } }
        public Endereco Entrega { get; set; }


        public void AdicionarItem(Item item)
        {                        
            _Itens.Add(item);
        }

        public void RemoverItem(Guid itemId)
        {
            _Itens.RemoveWhere(a => a.Id == itemId);
        }

        public void CalcularTotais()
        {
            this.ValorTotal = this.ValorMercadoria - this.ValorDesconto;
        }

    }
}
