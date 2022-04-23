#nullable enable
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Backend
{
    public class User: IdentityUser
    {

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        public ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();
        public ICollection<InterviewComment> InterviewComments { get; set; } = new List<InterviewComment>();
        public  ICollection<Role> Roles { get; set; }
    }
}