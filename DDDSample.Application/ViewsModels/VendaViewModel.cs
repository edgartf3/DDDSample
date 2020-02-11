using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.ViewsModels
{
    public class VendaViewModel: EntidadeBase
    {
        public int Numero { get; private set; }
        public DateTime Data { get; set; }

        public Guid VendedorId { get; set; }
        public string VendedorNome { get; set; }

        public double ValorMercadoria { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorTotal { get; set; }
        public ICollection<Item> Itens { get; set; }


    }
}
