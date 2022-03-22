#nullable enable
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Backend
{
    public class User: IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }
}