using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class CompaniesController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public CompaniesController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Companies/All
        [HttpGet]
        public ActionResult<IEnumerable<CompanyFront>> GetCompanies()
        {
            var companies = _context.Companies
                .Include(c => c.Reviews).ThenInclude(c => c.Tag)
                .Include(c => c.Interviews)
                .ToArray();
            var frontCompanies = companies.Select(
                c => new CompanyFront(
                    c.Name,
                    c.Reviews.Count(),
                    c.Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average(),
                    c.Interviews.Count(),
                    c.Interviews.Select(i => i.Difficulty).DefaultIfEmpty(0).Average(),
                    c.Reviews.Select(r => r.Tag?.Name).Distinct().ToArray()
                    ));
            return Ok(frontCompanies);
        }

        // GET: api/Companies/Qualtrics
        [HttpGet("{name}")]
        public ActionResult<CompanyFront> GetCompany(string name)
        {
            //TODO: Would null be better for default Average
            var reviews = GetReviews(name);
            var interviews = GetInterviews(name);
            return Ok(new { 
                Company = new CompanyFront(
                    name,
                    reviews.Count(),
                    reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average(),
                    interviews.Count(),
                    interviews.Select(i => i.Difficulty).DefaultIfEmpty(0).Average(),
                    reviews.Select(r => r.Tag).Distinct().ToArray()
                    ),
                Reviews = reviews,
                Interviews = interviews
            });
        }

        private ICollection<InterviewFront> GetInterviews(string name)
        {
            var interviews = _context.Interviews
                .Where(r => r.Company.Name.Equals(name))
                .Select(
                r => new InterviewFront(
                    r.Difficulty,
                    r.Position,
                    r.Comment,
                    r.Tag.Name,
                    r.Issued
                    ));
            return interviews.ToArray();
        }

        private ICollection<ReviewFront> GetReviews(string name)
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
                    r.Issued
                    ));
            return reviews.ToArray();
        }
    }
}
