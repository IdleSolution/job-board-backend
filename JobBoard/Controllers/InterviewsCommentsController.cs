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
        [HttpGet("{interviewId}")]
        public ActionResult<IEnumerable<CommentFront>> GetComments(long interviewId)
        {
            var result = _context.InterviewComments.Include(c => c.Interview).Include(c => c.User)
                .Where(c => c.Interview.Id == interviewId).ToArray()
                .Select(r => new CommentFront(r.Id, r.Message, r.Issued, r.User.Email))
                .OrderBy(c => c.Issued);
            return Ok(result);
        }

        [HttpGet("user/{email}")]
        public ActionResult<IEnumerable<CommentFront>> GetUserInterviewCommnets(string email)
        {
            var result = _context.InterviewComments.Include(c => c.Interview).Include(c => c.User)
                .Where(c => c.User.Email.Equals(email)).ToArray()
                .Select(r => new CommentFront(r.Id, r.Message, r.Issued, r.User.Email))
                .OrderBy(c => c.Issued);
            return Ok(result);
        }

        // Post: api/InterviewsComments/4
        [Authorize]
        [HttpPost("{interviewId}")]
        public ActionResult<CommentFront> PostComment(long interviewId, [FromBody] CommentFront commentFront)
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

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<CommentFront> PutReview(long id, [FromBody] CommentFront commentFront)
        {
            InterviewComment interview = _context.InterviewComments.Find(id);
            if (HttpContext.User.Identity.Name.Equals(interview.User.Email))
            {
                interview.Message = commentFront.Message;
                _context.InterviewComments.Update(interview);
                _context.SaveChanges();
                return Ok(commentFront);
            }
            return BadRequest(commentFront);
        }

        [Authorize]
        [HttpDelete("{commentId}")]
        public ActionResult<CommentFront> DeleteComment(long commentId)
        {
            var comment = _context.InterviewComments.Include(c => c.User)
                .Single(c => c.Id == commentId);
            if (comment is not null && comment.User.Email.Equals(HttpContext.User.Identity.Name))
            {
                _context.InterviewComments.Remove(comment);
                _context.SaveChanges();
                CommentFront commentFront = new CommentFront(comment.Id, comment.Message, comment.Issued, comment.User.Email);
                return Ok(commentFront);
            }
            return BadRequest(commentId);
        }
    }
}
