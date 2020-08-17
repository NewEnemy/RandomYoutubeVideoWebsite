using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomYoutubeVideo.Data;
using RandomYoutubeVideo.Models;

namespace RandomYoutubeVideo.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataBaseContext _context;
        public AdminController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            return View("Import");
        }
        [HttpPost]
        public IActionResult Import(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                return Content(reader.ReadToEnd());
            }
               
        }

        [HttpPost]
        public IActionResult SerachForNewIDS([Bind("Api","NumberOfQuerrys")] AdminModel adminModel)
        {
            return View();
        }
    }
}