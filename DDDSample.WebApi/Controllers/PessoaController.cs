using DDDSample.Application.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : BaseController<PessoaViewModel>
    {
    }
}