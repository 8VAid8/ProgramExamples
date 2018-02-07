using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MathFunctionWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MathFunctionController : Controller
    {
        [HttpGet("GetResult/{x}")]
        public string GetResult(double x)
        {
            // = 0.31;
            double A = Math.Sqrt(Math.Log(4.0 / 3.0 + x) + 9.0 / 7.0) -
            Math.Pow(Math.E, (-Math.Sin(1.3 * x - 0.7)));
            return $"Результат функции №1 (при x = {x}):{A}";
        }
    }
}
