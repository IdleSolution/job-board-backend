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
    public class CompaniesController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public CompaniesController(JobBoardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyFront>> GetCompanies()
        {
            var companies = _context.Companies
                .Include(c => c.Reviews)
                .ToArray();
            var frontCompanies = companies.Select(
                c => new CompanyFront(
                    c.Name,
                    c.Reviews.Count(),
                    c.Reviews.Select(r => r.Rating).Average(),
                    c.Reviews.Select(r => r.Tag).Distinct().ToArray()
                    ));
            return Ok(frontCompanies);
        }

        // GET: api/Companies/Qualtrics
        [HttpGet("{name}")]
        public ActionResult<CompanyFront> GetTodoItem(string name)
        {
            var companies = _context.Companies
                .Include(c => c.Reviews)
                .ToArray();
            var frontCompanies = companies.Select(
                c => new CompanyFront(
                    c.Name,
                    c.Reviews.Count(),
                    c.Reviews.Select(r => r.Rating).Average(), 
                    c.Reviews.Select(r => r.Tag).Distinct().ToArray()
                    ));
            return Ok(frontCompanies.SingleOrDefault(c => c.Name.Equals(name)));
        }
    }
}
