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
        public double ValorMercadoria { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorTotal { get; set; }
        public IReadOnlyCollection<Item> Itens { get { return _Itens.ToArray(); } }
        public Endereco Entrega { get; set; }


        public void AdicionarItem(Guid produtoId, double quantidade, IInjector injector)
        {

            //var x = _Itens.Where(a => a.ProdutoId == produtoId).FirstOrDefault();
            //if (x != null)
            //{
            //    throw new Exception("Produto já lançado");
            //}

            //Como
            var repProduto = injector.Get<IBaseRepository<Produto>>();
            var produto = repProduto.Get(produtoId);



            var item = Item.NovoItem(produtoId, quantidade);
            _Itens.Add(item);
        }

        public void RemoverItem(Guid itemId)
        {
            _Itens.RemoveWhere(a => a.Id == itemId);
        }

    }
}
