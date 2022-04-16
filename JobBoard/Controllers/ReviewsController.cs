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
    public class ReviewsController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public ReviewsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Reviews/Qualtrics
        [Authorize]
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<ReviewFront>> GetReviews(string name)
        {
            var reviews = _context.Reviews.Include(r => r.User)
                .Where(r => r.Company.Name.Equals(name))
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
            return Ok(reviews);
        }

        // Post: api/Reviews/Qualtrics
        [Authorize]
        [HttpPost("{name}")]
        public ActionResult<ReviewFront> PostReview(string name, [FromBody] ReviewFront reviewFront)
        {
            if (_context.Companies.Any(c => c.Name.Equals(name)) && HttpContext.User.Identity.Name.Equals(reviewFront.CreatorEmail))
            {
                Review review = CreateReview(name, reviewFront);
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return Ok(reviewFront);
            }
            return BadRequest(reviewFront);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<ReviewFront> DeleteReview(long id)
        {
            var review = _context.Reviews.Include(r=>r.Tag).Include(r=>r.User).SingleOrDefault(r=>r.Id==id);
            if (review is not null && review.User.Email.Equals(HttpContext.User.Identity.Name))
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                ReviewFront reviewFront = new ReviewFront(review.Id, review.Rating, review.Position, review.Comment,review.Tag.Name, review.From, review.To, review.To == null && review.From != null, review.Issued,review.User.Email);
                return Ok(reviewFront);
            }
            return BadRequest(id);
        }

        private Review CreateReview(string name, ReviewFront reviewFront)
        {
            var user = _context.Users.Single(u => u.Email.Equals(HttpContext.User.Identity.Name));
            var company = _context.Companies.Single(c => c.Name.Equals(name));
            var tag = _context.Tags.Single(t => t.Name.Equals(reviewFront.Tag));
            return new Review(company.Id, company, reviewFront.Rating, reviewFront.Position, reviewFront.Comment, tag, reviewFront.From, reviewFront.IsStillWorking? null:reviewFront.To, reviewFront.Issued, user);
        }
    }
}
