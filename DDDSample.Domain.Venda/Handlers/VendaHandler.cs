using DDDSample.Domain.Core;
using DDDSample.Domain.Core.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSample.Domain.Services
{
    public class VendaHandler : BaseHandler<Venda>, IVendaHandler
    {
        private IBaseRepository<Produto> _produtoRepository;


        public VendaHandler(
            IBaseRepository<Venda> baseRepository,
            IBaseRepository<Produto> produtoRepository) : base(baseRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarItem(Guid vendaId, Guid produtoId, double quantidade)
        {
            var produto = _produtoRepository.Get(produtoId);

            if (produto == null)
            {
                throw new Exception("Produto não existe");
            }

            if (produto.Ativo == false)
            {
                throw new Exception("Produto está inativo");
            }


            var venda = _baseRepository.Get(vendaId);            

            var item = new Item();            
            item.Preco = produto.Preco;
            item.ProdutoId = produtoId;
            item.Quantidade = quantidade;
            item.SubTotal = item.Quantidade * item.Preco;
            item.ValorDesconto = 0;
            item.Total = item.SubTotal - item.ValorDesconto;

            venda.AdicionarItem(item);

            venda.ValorMercadoria += item.SubTotal;
            venda.ValorDesconto += item.ValorDesconto;

            venda.CalcularTotais();

            

            _baseRepository.Update(venda);

                      

        }

        public void DarDesconto(Guid vendaId, double desconto)
        {
            var venda = _baseRepository.Get(vendaId);
            
            venda.ValorDesconto = desconto;
            venda.ValorTotal = venda.ValorMercadoria - venda.ValorDesconto;

            var percentual = (venda.ValorDesconto / venda.ValorMercadoria) * 100;

            if (venda.Vendedor.PercentualDescontoMaximo < percentual)
            {
                throw new Exception("Desconto não permitido");
            }

            

            _baseRepository.Update(venda);
            
        }

        public Venda NovaVenda()
        {
            var venda = new Venda();

            venda.Data = DateTime.Now;

            _baseRepository.Create(venda);

            return venda;
        }

        public void RemoverItem(Guid vendaId, Guid itemId)
        {
            var venda = _baseRepository.Get(vendaId);
            var item = venda.Itens.Where(a => a.Id == itemId).FirstOrDefault();

            venda.ValorMercadoria -= item.SubTotal;
            venda.ValorDesconto -= item.ValorDesconto;
            venda.CalcularTotais();

            venda.RemoverItem(itemId);

            _baseRepository.Update(venda);
        }
    }
}
