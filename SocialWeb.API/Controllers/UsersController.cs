using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

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