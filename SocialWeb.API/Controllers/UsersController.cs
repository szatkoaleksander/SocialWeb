using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]   
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetAsync(id);

            if(user == null)
             {
                 return NotFound();
             }

             return Ok(user);
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);

            if(user == null)
             {
                 return NotFound();
             }

             return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUser command)
        {
            await DispatchAsync(command);
           
            return Created($"users/user.Email", null);
        }
    }
}