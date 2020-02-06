using DDDSample.Domain.Core.Attributes;
using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class Item: EntidadeBase
    {
        [NotPersist]
        public virtual Produto Produto { get; set; }

        public Guid ProdutoId { get; set; }

        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double SubTotal { get; set; }
        public double ValorDesconto { get; set; }
        public double Total { get; set; }

        public static Item NovoItem(Produto produto, double quantidade)
        {
            return new Item()
            {
                ProdutoId = produto.Id,
                Quantidade = quantidade,
                Preco = produto.Preco,
                Total = quantidade * produto.Preco
            };
        }
    }
}
