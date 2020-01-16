using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Interfaces
{
    public interface IItem
    {
       IProduto Produto { get; set; }
       double Quantidade { get; set; }
       double Preco { get; set; }
       double SubTotal { get; set; }
       double ValorDesconto { get; set; }
       double Total { get; set; }
    }
}
