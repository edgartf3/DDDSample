using DDDSample.Application.Services;
using DDDSample.Domain.Entities;
using DDDSample.WebApi.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : BaseController<Venda>
    {
        [HttpPost]
        [Route("additem")]
        public async Task<IActionResult> Create([FromServices] VendaServiceApp service, [FromBody] AddItemRequest req)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.AddItem(req.VendaId, req.ProdutoId, req.Quantidade);
                tsc.SetResult(CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }


    }
}