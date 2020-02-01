using DDDSample.Application.Core.Interfaces;
using DDDSample.Application.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoAtividadeController : ControllerBase
    {
        private IBaseServiceApp<RamoAtividadeViewModel> _appService;

        public RamoAtividadeController(IBaseServiceApp<RamoAtividadeViewModel> appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RamoAtividadeViewModel entity)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                _appService.Create(entity);
                tsc.SetResult(Ok());
            }
            catch (Exception e)
            {
                tsc.SetResult(NotFound());
            }
            return await tsc.Task;
        }

    }
}