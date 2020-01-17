using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Interfaces
{
    public interface IEntidadeBase
    {
        Guid Id { get; set; }
        DateTime CriadoEm { get; set; }
    }
}
