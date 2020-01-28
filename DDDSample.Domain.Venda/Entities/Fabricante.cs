using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Fabricante : EntidadeBase
    {
<<<<<<< HEAD
        public Fabricante(string descricao)
        {
            this.Descricao = descricao;

=======
        public Fabricante(string descricao, Guid id)
        {
            this.Descricao = descricao;
            this.Id = id;

        }

        public Fabricante(string descricao)
        {
            this.Descricao = descricao;
>>>>>>> 397fc590adfb3a2a5a095a83686192d24a075271
        }

        public Fabricante()
        {

        }
        public string Descricao { get; set; }


    }
}
