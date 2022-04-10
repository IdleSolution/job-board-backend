using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Contexts;
using JobBoard.Models.Frontend;
using Microsoft.AspNetCore.Identity;
using JobBoard.Models.Backend;
using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;

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
                return Ok(GetUserInfo(credentials.Email));
            }
            return BadRequest(result.Errors);
        }
        // TODO: delete this
        [HttpGet("login/{email}/{pass}")]
        public async Task<ActionResult<string>> LoginUser(string email, string pass)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.PasswordSignInAsync(user, pass, true, false);
            if(result.Succeeded)
                return Ok(GetUserInfo(email));
            return BadRequest();
        }
        // POST: api/user/Login
        [HttpPost("login")]
        public async Task<ActionResult<UserFront>> LoginUser([FromBody] LoginCredentials credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            var result = await _signInManager.PasswordSignInAsync(user, credentials.Password, true, false);
            if (result.Succeeded)
                return Ok(GetUserInfo(credentials.Email));
            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<UserFront> GetUser()
        {
            var email = HttpContext.User.Identity.Name;
            return Ok(GetUserInfo(email));
        }

        [HttpGet("logout")]
        public async Task<ActionResult> LogoutUser()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        private UserFront GetUserInfo(string email)
        {
            var user = _context.Users
                .Single(u => u.Email.Equals(email));
            return new UserFront(user.Email, user.UserName, CreateReview(email),CreateInterview(email));
        }

        private ICollection<InterviewFront> CreateInterview(string email)
        {
             var interviews = _context.Interviews
                 .Where(r => r.User.Email.Equals(email))
                 .Select(
                 r => new InterviewFront(
                     r.Id,
                     r.Difficulty,
                     r.Position,
                     r.Comment,
                     r.Tag.Name,
                     r.Issued,
                     r.User.Email
                     ));
            return interviews.ToArray();
        }

        private ICollection<ReviewFront> CreateReview(string email)
        {
            var reviews = _context.Reviews
                .Where(r => r.User.Email.Equals(email))
                .Select(
                r => new ReviewFront(
                    r.Id,
                    r.Rating,
                    r.Position,
                    r.Comment,
                    r.Tag.Name,
                    r.From,
                    r.To,
                    r.To == null && r.From != null,
                    r.Issued,
                    r.User.Email
                    ));
            return reviews.ToArray();
        }
    }
}
