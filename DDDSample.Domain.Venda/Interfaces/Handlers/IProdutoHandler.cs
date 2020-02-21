using DDDSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Interfaces.Handlers
{
    public interface IProdutoHandler
    {
        void Create(Produto produto);
    }
}
