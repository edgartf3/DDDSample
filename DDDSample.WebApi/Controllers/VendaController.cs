using DDDSample.Domain.Venda.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : BaseController<Venda>
    {
    }
}