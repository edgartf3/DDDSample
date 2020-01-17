using DDDSample.Domain.Venda.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Interfaces
{
    public interface IProduto: IEntidadeBase, IAutoValida
    {
        string Descricao { get; set; }
        double Preco { get; set; }

    }
}
