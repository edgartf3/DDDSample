using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DDDSample.Domain.Entities
{
    public class CaracteristicaFisica
    {
        [Key]
        public Guid PessoaId { get; set; }

        public string CorOlhos { get; set; }
        public string CorCabelo { get; set; }
        public double Peso { get; set; }              
        

    }
}
