using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomYoutubeVideo.Data;
using RandomYoutubeVideo.Models;
using RandomYoutubeVideo.SideScripts;

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
            ViewData["Message"] = "";
            return View("Import");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAll()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE[DataBaseModel]");
            
            await _context.SaveChangesAsync();
            ViewData["Message"] = "All Cleared!!";
            return View("Import");
        }
        [HttpPost]
        public async Task< IActionResult> Import(Microsoft.AspNetCore.Http.IFormFile file)
        {
            
            DataBaseModel bufferModel = new DataBaseModel();
            int Views = 0;
            double Rating = 0.0;
            
            List<DataBaseModel> entryToAdd = new List<DataBaseModel>();
            string buffer = "";
            
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    
                    buffer = await reader.ReadLineAsync();
                    if (buffer != "")
                    {
                        bufferModel = new DataBaseModel { Id = 0, VidId = buffer, Views = Views, Rating = Rating };

                        _context.Add(bufferModel);
                        await _context.SaveChangesAsync();
                    }


                }

            }

           


            return RedirectToAction("Index", "DataBaseModels");

        }


        public IActionResult SerachForNewIDS()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SerachForNewIDS([Bind("Api,NumberOfQuerrys")] AdminModel adminModel)
        {
            YoutubeVideoIdGenerator videoIdGenerator = new YoutubeVideoIdGenerator(adminModel.Api, adminModel.NumberOfQuerrys);
            return Content(adminModel.Api);
        }
    }
}