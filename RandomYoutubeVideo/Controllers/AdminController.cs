using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomYoutubeVideo.Data;

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
    }
}