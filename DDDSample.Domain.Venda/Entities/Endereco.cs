using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;

namespace DDDSample.Domain.Venda.Entities
{
    public class Endereco : EntidadeBase, IEndereco
    {
        public string Logradouro { get; set;}
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}