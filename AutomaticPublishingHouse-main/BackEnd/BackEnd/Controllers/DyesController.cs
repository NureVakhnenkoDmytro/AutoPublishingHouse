using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using BackEnd.Models.Dye;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DyesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DyesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Dyes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dye>>> GetDyes()
        {
            return await _context.Dyes.ToListAsync();
        }


        // POST: api/Dyes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dye>> PostDye([FromBody]AddDyeModel model)
        {
            var dye = new Dye() { Name = model.Name };
            _context.Dyes.Add(dye);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
