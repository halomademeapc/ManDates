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

        public async Task<IActionResult> Test()
        {
            if (!await db.Members.AnyAsync())
            {
                db.Groups.Add(new Group
                {
                    Name = "Test",
                    Members = Enumerable.Range(0, 8).Select(e => new Member
                    {
                        FirstName = e.ToString(),
                        LastName = e.ToString()
                    }).ToList()
                });
                await db.SaveChangesAsync();
            }

            return View(scheduleService.GenerateAgenda(await db.Members.ToListAsync()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
