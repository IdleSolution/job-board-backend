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
                .Include(c => c.Reviews)
                .Include(c => c.Interviews)
                .ToArray();
            var frontCompanies = companies.Select(
                c => new CompanyFront(
                    c.Name,
                    c.Reviews.Count(),
                    c.Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average(),
                    c.Interviews.Count(),
                    c.Interviews.Select(i => i.Difficulty).DefaultIfEmpty(0).Average(),
                    c.Reviews.Select(r => r.Tag).Distinct().ToArray()
                    ));
            return Ok(frontCompanies);
        }

        // GET: api/Companies/Qualtrics
        [HttpGet("{name}")]
        public ActionResult<CompanyFront> GetCompany(string name)
        {
            //Do we need it?
            //maybe it can be get from all companies
            //on the frontend?
            //TODO: optimize
            //TODO: Would null be better for default Average
            var companies = _context.Companies
                .Include(c => c.Reviews)
                .Include(c => c.Interviews)
                .ToArray();
            var frontCompanies = companies.Select(
                c => new CompanyFront(
                    c.Name,
                    c.Reviews.Count(),
                    c.Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average(),
                    c.Interviews.Count(),
                    c.Interviews.Select(i => i.Difficulty).DefaultIfEmpty(0).Average(),
                    c.Reviews.Select(r => r.Tag).Distinct().ToArray()
                    ));
            return Ok(frontCompanies.SingleOrDefault(c => c.Name.Equals(name)));
        }
    }
}
