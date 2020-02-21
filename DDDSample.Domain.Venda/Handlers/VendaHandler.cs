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
        private IBaseRepository<Vendedor> _vendedorRepository;


        public VendaHandler(
            IBaseRepository<Venda> baseRepository,
            IBaseRepository<Vendedor> vendedorRepository,
            IBaseRepository<Produto> produtoRepository) : base(baseRepository)
        {
            _produtoRepository = produtoRepository;
            _vendedorRepository = vendedorRepository;
        }

        public void AdicionarItem(Guid vendaId, Guid produtoId, double quantidade)
        {
            var produto = _produtoRepository.Get(produtoId);

            if (produto == null)
            {
                throw new Exception("Produto não existe");
            }

            //if (produto.Ativo == false)
            //{
            //    throw new Exception("Produto está inativo");
            //}


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
            
            var sql = "Update Fabricantes Set Descricao = 'Raimundo 6' where Id = '26CA2C84-9C2E-4B0D-5165-08D7B0CEB838'";
            _baseRepository.ExecuteSql(sql);
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
            
            venda.Vendedor = _vendedorRepository.GetAll().FirstOrDefault();
            if (venda.Vendedor == null)
            {
                throw new Exception("Cadastre um vendedor");
            }
            
            venda.VendedorId = venda.Vendedor.Id;
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
