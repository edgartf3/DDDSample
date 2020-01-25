using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Fabricante : EntidadeBase
    {
        public Fabricante(string descricao)
        {
            this.Descricao = descricao;

        }

        public Fabricante()
        {

        }
        public string Descricao { get; set; }


    }
}
