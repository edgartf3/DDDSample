using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Interfaces
{
    public interface IEndereco
    {
        string Logradouro { get; set; }
        string Numero { get; set; }
        string Complemento { get; set; }
        string CEP { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string UF { get; set; }
    }
}
