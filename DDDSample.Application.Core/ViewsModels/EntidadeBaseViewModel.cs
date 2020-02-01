using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.Core.ViewsModels
{
    public class EntidadeBaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CriadoEm { get; set; }
    }
}
