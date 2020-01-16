using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Services.Venda
{
    public class VendaService
    {
        
        public VendaService(IVenda venda, IEmail email, IVendaRepository repository)
        {

        }
        public void Finalizar()
        {

            Venda.finalizar();

            repository.Save(venda);

            Email.Enviar(Venda)
        }
    }
}
