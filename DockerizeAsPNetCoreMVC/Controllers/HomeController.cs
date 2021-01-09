using DockerizeAsPNetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DockerizeAsPNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;
        public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult ImageSave()
        {
            return View();
        }
        public IActionResult ImageShow()
        {
            var images = _fileProvider.GetDirectoryContents("wwwroot/images").Select(x => x.Name).ToList();
            return View(images);
        }
        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using FileStream stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
