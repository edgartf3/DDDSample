using DDDSample.Application.Core.Interfaces;
using DDDSample.Application.ViewsModels;
using DDDSample.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoAtividadeController : BaseController<RamoAtividadeViewModel>
    {
        
    }
}