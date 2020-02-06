using DDDSample.Domain.Entities;
using DDDSample.Framework.DataBase;
using NUnit.Framework;

namespace DDDSample.Repositories.Test
{
    [Order(3)]
    public class VendaTest
    {
        private Produto produto;
        private BaseRepository<Venda, SampleDBContext> _repository;
        private BaseRepository<Produto, SampleDBContext> _ProdutoRepository;

        [SetUp]
        public void Setup()
        {
            var context = TestHelper.GetContexto();
            this._repository = TestHelper.CriarRepositorio<Venda>(context);
            this._ProdutoRepository = TestHelper.CriarRepositorio<Produto>(context);
        }


        [Test]
        [Order(0)]
        public void AdicionarProduto()
        {
            produto = new Produto("Produto C", 20);
            _ProdutoRepository.Create(new Produto("Produto A", 5));
            _ProdutoRepository.Create(new Produto("Produto B", 10));
            _ProdutoRepository.Create(produto);
        }


        [Test]
        [Order(1)]
        public void IncluirVenda()
        {
            var venda = new Venda();
            venda.AdicionarItem(produto.Id, 2);
            _repository.Create(venda);
        }
    }
}
