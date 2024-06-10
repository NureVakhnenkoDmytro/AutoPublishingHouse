using BackEnd.Models.Statistic;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StatisticsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("dye")]
        public IActionResult GetColorStatistic()
        {
            var materials = _context.Materials
                .Include(m => m.Dye);

            var groups = materials
                .GroupBy(m => m.Dye.Name);

            var statistic = groups
                .Select(d => new ColorStatisticModel
                {
                    ColorName = d.Key,
                    MaterialCount = d.Count()
                })
                .ToList();

            return Ok(statistic);
        }
    }
}
