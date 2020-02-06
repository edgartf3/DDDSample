using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Request
{
    public class AddItemRequest
    {
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public double Quantidade { get; set; }
    }
}
