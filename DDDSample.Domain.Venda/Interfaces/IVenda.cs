using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Interfaces
{
    public interface IVenda
    {
       int Numero { get; set; }
       DateTime Data { get; set; }
       ICliente Cliente { get; set; }
       double ValorMercadoria { get; set; }
       double ValorDesconto { get; set; }
       double ValorTotal { get; set; }
       List<IItem> Itens { get; set; }
       IEndereco Entrega { get; set; }

    }
}
