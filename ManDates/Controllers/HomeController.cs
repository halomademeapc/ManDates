using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManDates.Models;
using ManDates.Services;
using ManDates.Data;
using Microsoft.EntityFrameworkCore;
using ManDates.Models.Entities;

namespace ManDates.Controllers
{
    public class HomeController : Controller
    {
        private ScheduleService scheduleService;
        private DateDbContext db;

        public HomeController(ScheduleService scheduleService, DateDbContext db)
        {
            this.scheduleService = scheduleService;
            this.db = db;
        }

        public IActionResult Index()
        {
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
