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
            var reviews = _context.Reviews
                .Where(r => r.Company.Name.Equals(name))
                .Select(
                r => new ReviewFront(
                    r.Rating,
                    r.Position,
                    r.Comment,
                    r.Tag.Name,
                    r.From,
                    r.To,
                    r.To == null && r.From != null,
                    r.Issued
                    ));
            return Ok(reviews);
        }

        // Post: api/Reviews/Qualtrics
        [Authorize]
        [HttpPost("{name}")]
        public ActionResult<ReviewFront> PostReview(string name, [FromBody] ReviewFront reviewFront)
        {
            if (_context.Companies.Any(c => c.Name.Equals(name)))
            {
                Review review = CreateReview(name, reviewFront);
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return Ok(reviewFront);
            }
            return NotFound(reviewFront);
        }

        private Review CreateReview(string name, ReviewFront reviewFront)
        {
            var company = _context.Companies.Single(c => c.Name.Equals(name));
            var tag = _context.Tags.Single(t => t.Name.Equals(reviewFront.Tag));
            return new Review(company.Id, company, reviewFront.Rating, reviewFront.Position, reviewFront.Comment, tag, reviewFront.From, reviewFront.IsStillWorking? null:reviewFront.To, reviewFront.Issued);
        }
    }
}
