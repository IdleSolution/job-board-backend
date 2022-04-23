using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.Contexts;
using JobBoard.Models.Backend;
using JobBoard.Models.Frontend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{       
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin, Moderator")]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public RolesController( UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("Users")]
        public async Task<ActionResult<UserFront>> GetUsersRoles()
        {
            var res = new List<UserRolesFront>();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                res.Add(new UserRolesFront(user.Email, user.UserName, roles));
            }
            return Ok(res);
        }
        
        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("Users/{name}")]
        public async Task<ActionResult<UserFront>> GetUserRoles(string name)
        {
            var res = new List<UserRolesFront>();
            var user = await _userManager.FindByNameAsync(name);
            var usl = new UserRolesFront(user.Email, user.UserName, await _userManager.GetRolesAsync(user));
            return Ok(usl);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("ChangeRole")]
        public async Task<ActionResult> AddRoles([FromBody] UserRolesFront userRolesFront)
        {
            var user = await _userManager.FindByEmailAsync(userRolesFront.Email);
            var result = await _userManager.AddToRolesAsync(user, userRolesFront.Roles);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }
        public async Task<ActionResult> RemoveRoles([FromBody] UserRolesFront userRolesFront)
        {
            var user = await _userManager.FindByEmailAsync(userRolesFront.Email);
            var result = await _userManager.RemoveFromRolesAsync(user, userRolesFront.Roles);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }
    }
}