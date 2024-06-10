using AutoMapper;
using BackEnd.Models.PrintingPress;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintingPressController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PrintingPressController(ApplicationContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPrintingPress()
        {
            return Ok(_context.PrintingPresses);
        }

        [HttpPost]
        public IActionResult CreatePrintingPress([FromBody] CreatePrintingPressModel model)
        {
            var printingPress = _mapper.Map<PrintingPress>(model);

            _context.Add(printingPress);
            _context.SaveChanges();

            return Ok();
        }
    }
}
