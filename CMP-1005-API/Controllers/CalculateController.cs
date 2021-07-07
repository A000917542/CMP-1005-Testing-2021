using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMP_1005_Calculator;
using Microsoft.Extensions.Logging;

namespace CMP_1005_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public double add(double leftNumber, double rightNumber)
        {
            _logger.LogTrace("Made it into the add method");
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44377");
            _logger.LogTrace("Set Cors");
            var ret = Calculator.add(leftNumber, rightNumber);
            _logger.LogInformation($"Calculation result was {ret}");
            return ret;
        }

        [HttpGet]
        public double mul(double leftNumber, double rightNumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44377");
            var ret = Calculator.multiply(leftNumber, rightNumber);
            return ret;
        }

        [HttpGet]
        public double sub(double leftNumber, double rightNumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44377");
            var ret = Calculator.subtract(leftNumber, rightNumber);
            return ret;
        }

        [HttpGet]
        public double div(double leftNumber, double rightNumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44377");
            //Response.Headers.Add("Location", "https://www.yahoo.com");
            double result = 0;

            try
            {
                result = Calculator.divide(leftNumber, rightNumber);
            }
            catch (DivideByZeroException)
            {
                Response.StatusCode = 400; // Set to Bad Request
            }

            return result;
        }
    }
}
