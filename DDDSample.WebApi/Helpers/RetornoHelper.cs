using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDSample.WebApi.Helpers
{
    public class RetornoHelper
    {
        public static IActionResult CreateResponse(object obj, int statusCode)
        {
            return new JsonResult(obj)
            {
                StatusCode = statusCode
            };
        }
    }
}
