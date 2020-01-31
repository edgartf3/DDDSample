using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.ViewsModels
{
    public class EntidadeViewModelBase
    {
        public Guid Id { get; set; }
        public DateTime? CriadoEm { get; set; }
    }
}
