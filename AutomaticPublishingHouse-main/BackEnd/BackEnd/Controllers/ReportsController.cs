using BackEnd.Models.Report;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ReportsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("printing-press")]
        public IActionResult GetPrintingPressReport()
        {
            var report = _context.Editions
                .Include(e => e.PrintingPress)
                .GroupBy(e => e.PrintingPress.Name)
                .Select(g => new PrintingPressReportModel
                {
                    Name = g.Key,
                    Count = g.Select(e => e.Count).Sum()
                });

            return Ok(report);
        }
    }
}
