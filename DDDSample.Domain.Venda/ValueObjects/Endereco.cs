using DDDSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDDSample.Domain.ValuesObject
{
    [Owned]
    public class Endereco
    {
        
        private string _cep;


        public Pessoa Pessoa { get; set; }
        public Guid PessoaId { get; set; }

        public string Logradouro { get; set;}
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get { return _cep; } set { this.SetCep(value); } }                
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public int IBGE { get; set; }

        public void SetCep(string value)
        {
            if (value != null)
            {
                if (value.Length == 8)
                {
                    _cep = value;

                }
                else
                {
                    throw new Exception("Cep Inválido");
                }
            }
            
        }
        
    }
}