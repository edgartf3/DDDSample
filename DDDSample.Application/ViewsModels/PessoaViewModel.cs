using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.ViewsModels
{
    public class PessoaViewModel: EntidadeBase
    {
        public PessoaViewModel()
        {
            this.Dependentes = new HashSet<DependenteViewModel>();
        }
        public string Nome { get; set; }
        public string Cpf_CNPJ { get; set; }
        public Guid RamoAtividadeId { get; set; }
        public string RamoAtividadeDescricao { get; set; }
        public string EntregaCEP { get; set; }

        public ICollection<DependenteViewModel> Dependentes { get; set; }
    }
}
