using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Domain.Venda.Entities;
using DDDSample.Domain.Venda.Interfaces;
using DDDSample.Services.Venda.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Venda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public static IActionResult CreateResponse(object obj, int statusCode)
        {
            return new JsonResult(obj)
            {
                StatusCode = statusCode
            };
        }

        [HttpGet]
        public IEnumerable<IProduto> get2([FromServices] IProdutoService produtoService)
        {
            return produtoService.Get();
        }

        [HttpGet]        
        [Route("async")]
        public async Task<IActionResult> Get([FromServices] IProdutoService produtoService)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var produtos = produtoService.Get();                
                
                tsc.SetResult(CreateResponse(produtos, 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }
    }
}