using System;
using System.Collections.Generic;
using System.IO;
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

        public string mimeType { get; set; }

        public string imageData { get; set; }

        public string asciiData { get; set; }

        public string imageFileName { get; set; }

        public TestPageModel(ILogger<TestPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost(IFormFile testFile)
        {
            var ext = testFile.FileName.Substring(testFile.FileName.LastIndexOf("."));

            var fileName = String.Concat(Guid.NewGuid(), ext);

            var filePath = String.Concat("C:\\Temp", Path.DirectorySeparatorChar, fileName);

            using (var readStream = testFile.OpenReadStream())
            {
                using (var fileStream = System.IO.File.Create(filePath)) // IDisposable
                {
                    readStream.CopyTo(fileStream);
                }
            }

            imageFileName = fileName;

            //returnBase64(testFile);

            //returnEncoding(testFile, System.Text.Encoding.UTF32);
        }

        private void returnEncoding(IFormFile testFile, System.Text.Encoding encoding)
        {
            var mime = testFile.ContentType;

            var readStream = testFile.OpenReadStream();

            var memStream = new MemoryStream();
            readStream.CopyTo(memStream);

            var bytes = memStream.ToArray();

            var image = encoding.GetString(bytes);

            asciiData = image;

            memStream.Dispose();

            readStream.Dispose();
        }

        private void returnBase64(IFormFile testFile)
        {
            var mime = testFile.ContentType;

            var readStream = testFile.OpenReadStream();

            var memStream = new MemoryStream();
            readStream.CopyTo(memStream);

            var bytes = memStream.ToArray();

            var image = Convert.ToBase64String(bytes);

            mimeType = mime;
            imageData = image;

            memStream.Dispose();

            readStream.Dispose();
        }
    }
}
