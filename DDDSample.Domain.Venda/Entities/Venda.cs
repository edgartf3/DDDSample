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
            //Regra 1 verifica se o item já não está na venda
            var x = _Itens.Where(a => a.ProdutoId == produtoId).FirstOrDefault();
            if (x != null)
            {
                throw new Exception("Produto já lançado");
            }

            
            //Regra 2 verifica se o produto está ativo
            //*Pergunta: Neste ponto preciso de uma instancia do produto, mas recebi só o Guid Id
            //           Preciso dar um get produto, no repositório isso está em um lugar adequado, ou deveria ter recebido o produto via parametro ?
            
            var repProduto = injector.Get<IBaseRepository<Produto>>(); //*Pergunta: esse Injector que fiz está certo, isso se usa desta forma ?

            var produto = repProduto.Get(produtoId);
            if (produto.Ativo == false)
            {
                throw new Exception("Produto não pode ser vendido");
            }

            var item = Item.NovoItem(produto, quantidade);            
            _Itens.Add(item);
        }

        public void RemoverItem(Guid itemId)
        {
            _Itens.RemoveWhere(a => a.Id == itemId);
        }

    }
}
