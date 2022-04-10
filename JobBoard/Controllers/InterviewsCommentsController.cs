using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.Contexts;
using JobBoard.Models;
using JobBoard.Models.Frontend;
using JobBoard.Models.Backend;
using Microsoft.AspNetCore.Authorization;

namespace JobBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsCommentsController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public InterviewsCommentsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/InterviewsComments/4
        [Authorize]
        [HttpGet("{interviewId}")]
        public ActionResult<IEnumerable<CommentFront>> GetComments(long interviewId)
        {
            var result = _context.InterviewComments.Include(c => c.Interview).Include(c => c.User)
                .Where(c => c.Interview.Id == interviewId).ToArray()
                .Select(r => new CommentFront(r.Id, r.Message, r.Issued, r.User.Email))
                .OrderBy(c => c.Issued);
            return Ok(result);
        }

        // Post: api/InterviewsComments/4
        [Authorize]
        [HttpPost("{interviewId}")]
        public ActionResult<CommentFront> PostReview(long interviewId, [FromBody] CommentFront commentFront)
        {
            if (_context.Interviews.Any(r => r.Id == interviewId) && HttpContext.User.Identity.Name.Equals(commentFront.CreatorEmail))
            {
                var interview = _context.Interviews.Find(interviewId);
                var user = _context.Users.Single(u => u.Email.Equals(commentFront.CreatorEmail));

                InterviewComment comment = new InterviewComment(commentFront.Message, commentFront.Issued, user, interviewId);
                _context.InterviewComments.Add(comment);
                _context.SaveChanges();
                return Ok(commentFront);
            }
            return BadRequest(commentFront);
        }


    }
}
