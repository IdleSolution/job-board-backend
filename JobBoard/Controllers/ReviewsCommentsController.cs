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
    public class ReviewsCommentsController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public ReviewsCommentsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/ReviewsComments/4
        [Authorize]
        [HttpGet("{reviewId}")]
        public ActionResult<IEnumerable<CommentFront>> GetReviews(long reviewId)
        {
            var result = _context.ReviewComments.Include(c => c.Review).Include(c=>c.User)
                .Where(c => c.Review.Id == reviewId).ToArray()
                .Select(r => new CommentFront(r.Id, r.Message, r.Issued, r.User.Email))
                .OrderBy(c => c.Issued);
            return Ok(result);
        }

        // Post: api/ReviewsComments/4
        [Authorize]
        [HttpPost("{reviewId}")]
        public ActionResult<CommentFront> PostReview(long reviewId, [FromBody] CommentFront commentFront)
        {
            if (_context.Reviews.Any(r => r.Id == reviewId) && HttpContext.User.Identity.Name.Equals(commentFront.CreatorEmail))
            {
                var review = _context.Reviews.Find(reviewId);
                var user = _context.Users.Single(u => u.Email.Equals(commentFront.CreatorEmail));

                ReviewComment comment = new ReviewComment(commentFront.Message, commentFront.Issued, user, review);
                _context.ReviewComments.Add(comment);
                _context.SaveChanges();
                return Ok(commentFront);
            }
            return BadRequest(commentFront);
        }

        [Authorize]
        [HttpDelete("{commentId}")]
        public ActionResult<CommentFront> DeleteComment(long commentId)
        {
            var comment = _context.ReviewComments.Include(c => c.User)
                .Single(c => c.Id == commentId);
            if (comment is not null && comment.User.Email.Equals(HttpContext.User.Identity.Name))
            {
                _context.ReviewComments.Remove(comment);
                _context.SaveChanges();
                CommentFront commentFront = new CommentFront(comment.Id, comment.Message, comment.Issued, comment.User.Email);
                return Ok(commentFront);
            }
            return BadRequest(commentId);
        }

    }
}
