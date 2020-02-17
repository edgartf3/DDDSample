using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDDSample.WebApi.ReadOnly.Controllers
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
        public async Task<IActionResult> GetAll()
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                //1 - Criar uma conexão direta com o banco
                //2 - exeutar o select que quiser
                //3 - Retornar o resultado do select
                
                tsc.SetResult(CreateResponse("ok", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

    }
}