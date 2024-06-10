using AutoMapper;
using BackEnd.Models.Editions;
using BLL;
using DAL;
using Domain;
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
    public class EditionsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public EditionsController(IMapper mapper, ApplicationContext context, UserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateEdition([FromBody] CreateEditionModel model)
        {
            var user = _userService.GetAllNotDeletedUsers().First(u => u.Id == model.UserId);
            var print = _context.PrintingPresses.First(p => p.Id == model.PrintingPressId);
            var material = _context.Materials.First(p => p.Id == model.MaterialId);
            var edition = new Edition
            {
                Material = material,
                PrintingPress = print,
                User = user,
                Count = model.Count
            };

            _context.Add(edition);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEditions()
        {
            var editions = _context.Editions.
                Include(e => e.Material)
                .Include(e => e.PrintingPress)
                .Include(e => e.User)
                    .ThenInclude(u => u.Role);

            return Ok(editions);
        }
    }
}
