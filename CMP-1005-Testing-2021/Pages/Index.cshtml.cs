using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        }

        public void OnPost(double leftNumber, double rightNumber, string operation)
        {
            switch (operation)
            {
                case "add":
                    Result = leftNumber + rightNumber;
                    ResultSet = true;
                    break;
                case "sub":
                    Result = leftNumber - rightNumber;
                    ResultSet = true;
                    break;
                case "mul":
                    Result = leftNumber * rightNumber;
                    ResultSet = true;
                    break;
                case "div":
                    Result = leftNumber / rightNumber;
                    ResultSet = true;
                    break;
                default:
                    break;
            }
        }
    }
}
