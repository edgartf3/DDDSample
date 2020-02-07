using DDDSample.Application.Services;
using DDDSample.Application.Services.Interfaces;
using DDDSample.Domain.Entities;
using DDDSample.Domain.Interfaces.Services;
using DDDSample.WebApi.Helpers;
using DDDSample.WebApi.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpPost]
        [Route("AdicionarItem")]
        public async Task<IActionResult> AdicionarItem([FromServices] IVendaService service, [FromBody] AddItemRequest req)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.AdicionarItem(req.VendaId, req.ProdutoId, req.Quantidade);
                
                tsc.SetResult(RetornoHelper.CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(RetornoHelper.CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Route("RemoverItem")]
        public async Task<IActionResult> removerItem([FromServices] IVendaService service, [FromBody] AddItemRequest req)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.RemoverItem(req.VendaId, req.ItemId);

                tsc.SetResult(RetornoHelper.CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(RetornoHelper.CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }


        [HttpPost]
        [Route("Desconto")]
        public async Task<IActionResult> Desconto([FromServices] IVendaService service, [FromBody] AddItemRequest req)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.DarDesconto(req.VendaId, req.valor);
                tsc.SetResult(RetornoHelper.CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(RetornoHelper.CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Route("Nova")]
        public async Task<IActionResult> Nova([FromServices] IVendaService service)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.NovaVenda();

                tsc.SetResult(RetornoHelper.CreateResponse(result, 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(RetornoHelper.CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }


    }
}