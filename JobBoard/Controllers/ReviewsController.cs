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
                    r.Tag,
                    r.From,
                    r.To,
                    r.Issued
                    ));
            return Ok(reviews);
        }
    }
}
