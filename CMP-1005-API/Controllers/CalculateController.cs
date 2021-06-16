﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CMP_1005_Calculator;

namespace CMP_1005_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculateController : ControllerBase
    {
        [HttpGet]
        public double add(double leftNumber, double rightNumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Calculator.add(leftNumber, rightNumber);
        }

        [HttpGet]
        public double divide(double leftNumber, double rightNumber)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
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
