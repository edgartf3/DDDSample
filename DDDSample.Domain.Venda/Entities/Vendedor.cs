using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class Vendedor: EntidadeBase
    {
        public string Nome { get; set; }
        public double PercentualDescontoMaximo { get; set; }
    }
}
