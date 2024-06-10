using AutoMapper;
using BackEnd.Models.Material;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public MaterialController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMaterial([FromBody] CreateMaterialModel model)
        {
            var material = _mapper.Map<Material>(model);
            
            _context.Add(material);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMaterial()
        {
            return Ok(_context.Materials);
        }
    }
}
