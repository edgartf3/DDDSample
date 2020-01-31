using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Attributes
{
    public class Edgar: Attribute
    {
        public Edgar(string teste)
        {
            this.Teste = teste;

        }
        public string Teste { get; set; }
    }
}
