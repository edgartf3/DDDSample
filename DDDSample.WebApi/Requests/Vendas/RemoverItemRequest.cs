﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Requests.Vendas
{
    public class RemoverItemRequest
    {
        public Guid VendaId { get; set; }
        public Guid ItemId { get; set; }
    }
}
