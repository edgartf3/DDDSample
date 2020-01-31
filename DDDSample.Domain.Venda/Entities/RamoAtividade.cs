using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class RamoAtividade: EntidadeBase
    {
        public RamoAtividade()
        {

        }

        public RamoAtividade(string descricao)
        {
            this.Descricao = descricao;

        }

        public RamoAtividade(string descricao, Guid id)
        {
            this.Descricao = descricao;
            this.Id = id;
        }
        public string Descricao { get; set; }
    }
}
