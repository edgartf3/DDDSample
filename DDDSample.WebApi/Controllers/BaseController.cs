using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Domain.Core.Entities;
using DDDSample.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : EntidadeBase
    {
        public static IActionResult CreateResponse(object obj, int statusCode)
        {
            return new JsonResult(obj)
            {
                StatusCode = statusCode
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IBaseService<T> service)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var entities = service.GetAll();
                tsc.SetResult(CreateResponse(entities, 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromServices] IBaseService<T> service, [FromRoute] Guid id)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var entity = service.Get(id);
                tsc.SetResult(CreateResponse(entity, 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IBaseService<T> service, [FromBody] T entity)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.Create(entity);
                tsc.SetResult(CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IBaseService<T> service, [FromBody] T entity)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                //T obj = service.Get(entity.TryGetValue("Id"));



                service.Update(entity);
                tsc.SetResult(CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }


        [HttpDelete]        
        public async Task<IActionResult> DeleteModel([FromServices] IBaseService<T> service, [FromBody] T model)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.Delete(model);
                tsc.SetResult(CreateResponse("OK", 200));
            }
            catch (Exception e)
            {
                tsc.SetResult(CreateResponse(e.Message, 500));
            }
            return await tsc.Task;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteId([FromServices] IBaseService<T> service, [FromRoute] Guid id)
        {

            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                service.Delete(id);
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