using AutoMapper;
using BackEnd.Models.Users;
using BLL;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetAllNotDeletedUsers().First(u => u.Id == id);

            if (user == null)
            {
                return BadRequest("User is not exist");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            _userService.UpdateUser(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            _userService.DeleteUser(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserModel model)
        {
            var user = _mapper.Map<User>(model);
            _userService.AddUser(user);

            return Ok();
        }
    }
}
