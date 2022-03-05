using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Contexts;
using JobBoard.Models.Frontend;

namespace JobBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public TagsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTags()
        {
            var tags = _context.Tags
                .Select(t => t.Name)
                .ToArray();
            return Ok(tags);
        }

        [HttpPost]
        public ActionResult<string> PostTag([FromBody] string tag)
        {
            _context.Tags.Add(new Models.Backend.Tag(tag));
            _context.SaveChanges();
            return Ok(tag);
        }
    }
}
