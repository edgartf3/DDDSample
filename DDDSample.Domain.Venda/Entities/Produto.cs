using DDDSample.Domain.Venda.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Venda.Entities
{
    public class Produto : EntidadeBase, IProduto
    {
        private double preco = 0.00;        
        public string Descricao { get; set; }
        public double Preco
        {
            get
            {
                return preco;
            }
            set
            {
                if (value <= 0) throw new Exception("O preço deve ser maior que zero");
                this.preco = value;
            }
        }

        public bool IsValid()
        {
            return ((this.Preco > 0) && (this.Descricao != ""));
        }
        
    }
}
