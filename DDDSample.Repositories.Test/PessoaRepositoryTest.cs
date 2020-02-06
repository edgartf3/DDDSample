using DDDSample.Domain.Entities;
using DDDSample.Domain.ValuesObject;
using DDDSample.Framework.DataBase;
using NUnit.Framework;
using System;

namespace DDDSample.Repositories.Test
{
    [Order(2)]
    public class PessoaRepositoryTest
    {
        
        private SampleDBContext _context;
        private Guid id;
        private BaseRepository<Pessoa, SampleDBContext> repository;       

        [SetUp]
        public void Setup()
        {
            _context = TestHelper.GetContexto();

            repository = TestHelper.CriarRepositorio<Pessoa>(_context);            

        }

        [Test]
        [Order(0)]
        public void Incluir()
        {
            
            var pessoa = new Pessoa()
            {                
                Nome = "Edgar",
                RamoAtividadeId = Guid.Parse("23DF4BD9-0E02-47F9-91F4-4EFEF13DEDDB")
            };
            
            
            pessoa.Entrega = new Endereco();
            pessoa.Entrega.SetCep("12345678");


            pessoa.Dependentes.Add(new Dependente("Daise"));
            pessoa.Dependentes.Add(new Dependente("Rodrigo"));
            
            repository.Create(pessoa);
            id = pessoa.Id;

            var x = repository.Get(id);
            Assert.IsNotNull(x);
            Assert.AreEqual("Edgar", x.Nome);
            Assert.AreEqual(2, x.Dependentes.Count);
            
        }


        [Test]
        [Order(1)]
        public void Incluir_Caracteristica_Fisica()
        {

            var pessoa = new Pessoa()
            {
                Cpf_CNPJ = "12345678901",
                Nome = "Olimpio",
                RamoAtividadeId = Guid.Parse("23DF4BD9-0E02-47F9-91F4-4EFEF13DEDDB")
            };

            pessoa.Dependentes.Add(new Dependente("Julia"));
            pessoa.Dependentes.Add(new Dependente("Gabriela"));
            pessoa.Dependentes.Add(new Dependente("Valdilene"));

            pessoa.CaracteristicasFisica = new CaracteristicaFisica();
            pessoa.CaracteristicasFisica.CorCabelo = "Castanhos";
            pessoa.CaracteristicasFisica.CorOlhos = "Preto";
            pessoa.CaracteristicasFisica.Peso = 99;


            repository.Create(pessoa);
            id = pessoa.Id;

            var x = repository.Get(id);
            Assert.IsNotNull(x);
            Assert.AreEqual("Olimpio", x.Nome);
            Assert.AreEqual(3, x.Dependentes.Count);
            Assert.AreEqual(99, x.CaracteristicasFisica.Peso);

        }

        [Test]
        [Order(2)]
        public void Incluir_RamoAtividade()
        {
            

            var pessoa = new Pessoa()
            {
                Cpf_CNPJ = "12345678901",
                Nome = "Matheus",
                RamoAtividadeId = Guid.Parse("23DF4BD9-0E02-47F9-91F4-4EFEF13DEDDB")
            };

            
            repository.Create(pessoa);
            id = pessoa.Id;

            var x = repository.Get(id);
            Assert.IsNotNull(x);
            Assert.AreEqual("Matheus", x.Nome);
            
        }



        [Test]
        [Order(900)]
        public void Delete()
        {            
            repository.Delete(id);
            var x = repository.Get(id);         
            Assert.IsNull(x);
        }
    }
}
