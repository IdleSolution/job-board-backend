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
    public class InterviewsController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public InterviewsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Intereviews/Qualtrics
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<InterviewFront>> GetInterviews(string name)
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
            return Ok(interviews);
        }
    }
}
