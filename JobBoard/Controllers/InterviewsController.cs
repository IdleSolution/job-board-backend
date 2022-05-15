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
    public class InterviewsController : ControllerBase
    {
        private readonly JobBoardContext _context;
        public InterviewsController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Intereviews/Qualtrics
        [Authorize]
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<InterviewFront>> GetInterviews(string name)
        {
            var interviews = _context.Interviews
                .Where(r => r.Company.Name.Equals(name))
                .Select(
                r => new InterviewFront(
                    r.Id,
                    r.Difficulty,
                    r.Position,
                    r.Comment,
                    r.Tag.Name,
                    r.Issued,
                    r.User.Email
                    ));
            return Ok(interviews);
        }

        [HttpGet("user/{email}")]
        public ActionResult<IEnumerable<InterviewFront>> GetUserInterviews(string email)
        {
            var interviews = _context.Interviews
                 .Where(r => r.User.Email.Equals(email))
                 .Select(
                 r => new InterviewFront(
                     r.Id,
                     r.Difficulty,
                     r.Position,
                     r.Comment,
                     r.Tag.Name,
                     r.Issued,
                     r.User.Email
                     ));
            return Ok(interviews);
        }

        // Post: api/Intereviews/Qualtrics
        [Authorize]
        [HttpPost("{name}")]
        public ActionResult<InterviewFront> PostInterview(string name, [FromBody] InterviewFront interviewFront)
        {
            if (_context.Companies.Any(c => c.Name.Equals(name)) && HttpContext.User.Identity.Name.Equals(interviewFront.CreatorEmail))
            {
                Interview interview = CreateInterview(name, interviewFront);
                _context.Interviews.Add(interview);
                _context.SaveChanges();
                return Ok(interviewFront);
            }
            return BadRequest(interviewFront);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<InterviewFront> PutInterview(long id, [FromBody] InterviewFront interviewFront)
        {
            Interview interview = _context.Interviews.Find(id);
            if (HttpContext.User.Identity.Name.Equals(interview.User.Email))
            {
                interview.Comment = interviewFront.Comment;
                _context.Interviews.Update(interview);
                _context.SaveChanges();
                return Ok(interviewFront);
            }
            return BadRequest(interviewFront);
        }

        

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<InterviewFront> DeleteComment(long id)
        {
            var interview = _context.Interviews.Include(i=>i.Tag).Include(i=>i.User).SingleOrDefault(i=>i.Id==id);
            if (interview is not null && interview.User.Email.Equals(HttpContext.User.Identity.Name))
            {
                _context.Interviews.Remove(interview);
                _context.SaveChanges();
                InterviewFront interviewFront = new InterviewFront(interview.Id, interview.Difficulty, interview.Position, interview.Comment, interview.Tag.Name, interview.Issued, interview.User.Email);
                return Ok(interviewFront);
            }
            return BadRequest(id);
        }


        private Interview CreateInterview(string name, InterviewFront interviewFront)
        {
            var user = _context.Users.Single(u => u.Email.Equals(HttpContext.User.Identity.Name));
            var company = _context.Companies.Single(c => c.Name.Equals(name));
            var tag = _context.Tags.Single(t => t.Name.Equals(interviewFront.Tag));
            return new Interview(company.Id, company, interviewFront.Difficulty, interviewFront.Position, interviewFront.Comment, tag, interviewFront.Issued, user);
        }
    }
}
