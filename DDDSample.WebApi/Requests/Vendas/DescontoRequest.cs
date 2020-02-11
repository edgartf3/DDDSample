using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Requests.Vendas
{
    public class DescontoRequest
    {
        public Guid VendaId { get; set; }
        public double Valor { get; set; }

    }
}
