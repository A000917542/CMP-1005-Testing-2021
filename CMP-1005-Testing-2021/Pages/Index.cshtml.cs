using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMP_1005_Calculator;

namespace CMP_1005_Testing_2021.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public double Result
        {
            get; set;
        }

        public bool ResultSet
        {
            get; protected set;
        } = false;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation($"{User?.Identity?.Name} has made a Get Request.");
        }

        public void OnPost(double leftNumber, double rightNumber, string operation)
        {
            _logger.LogDebug($"Left number is {leftNumber}");
            _logger.LogDebug($"Right number is {rightNumber}");
            _logger.LogDebug($"Operation is {operation}");

            switch (operation)
            {
                case "add":
                    _logger.LogDebug("Operation selected was 'add'");
                    Result = Calculator.add(leftNumber, rightNumber);
                    ResultSet = true;
                    break;
                case "sub":
                    _logger.LogDebug("Operation selected was 'sub'");
                    Result = Calculator.subtract(leftNumber, rightNumber);
                    ResultSet = true;
                    break;
                case "mul":
                    _logger.LogDebug("Operation selected was 'mul'");
                    Result = Calculator.multiply(leftNumber, rightNumber); ;
                    ResultSet = true;
                    break;
                case "div":
                    _logger.LogDebug("Operation selected was 'div'");
                    Result = Calculator.divide(leftNumber, rightNumber);
                    ResultSet = true;
                    break;
                default:
                    break;
            }
        }
    }
}
