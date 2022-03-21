using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Contexts;
using JobBoard.Models.Frontend;
using Microsoft.AspNetCore.Identity;
using JobBoard.Models.Backend;
using System.Threading.Tasks;
using System.Security.Claims;

namespace JobBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JobBoardContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(JobBoardContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser([FromBody] LoginCredentials credentials)
        {
            if(await _userManager.FindByEmailAsync(credentials.Email) is not null)
            {
                return BadRequest($"user {credentials.Email} already exists");
            }
            var user = new User { UserName = credentials.Email, Email = credentials.Email };
            var result = await _userManager.CreateAsync(user, credentials.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                // TODO: return profile user info 
                return Ok("Registered and signed in");
            }
            return BadRequest(result.Errors);
        }
        // POST: api/user/Login
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginCredentials credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            await _signInManager.PasswordSignInAsync(user, credentials.Password, true, false);
            // TODO: return profile user info 
            return Ok();
        }
    }
}
