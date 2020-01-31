using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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