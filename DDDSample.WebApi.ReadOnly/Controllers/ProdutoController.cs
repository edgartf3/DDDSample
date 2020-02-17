using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DDDSample.WebApi.ReadOnly.Controllers
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IConfiguration _config;


        public ProdutoController(IConfiguration config)
        {
            _config = config;
        }

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

                using (var connection = new SqlConnection(_config.GetConnectionString("SampleConnection")))
                {
                    connection.Open();
                    var SeuObjeto = connection.Query<object>("Select Id, Descricao, Preco From Produtos");
                    tsc.SetResult(CreateResponse(SeuObjeto, 200));
                }                
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

    }
}