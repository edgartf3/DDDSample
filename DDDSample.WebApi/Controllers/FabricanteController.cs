﻿using DDDSample.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : BaseController<Fabricante>
    {
    }
}