using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CMP_1005_Testing_2021.Pages
{
    public class TestPageModel : PageModel
    {
        private readonly ILogger<TestPageModel> _logger;

        //[FromForm]
        //IFormFile uploadedFile { get; set; }

        public TestPageModel(ILogger<TestPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost(IFormFile testFile)
        {
            var filePath = System.IO.Path.GetTempFileName();

            using (var readStream = testFile.OpenReadStream())
            {
                using (var fileStream = System.IO.File.Create(filePath)) // IDisposable
                {
                    readStream.CopyTo(fileStream);
                }
            }
            
        }
    }
}
