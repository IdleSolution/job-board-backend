#nullable enable

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Backend
{
    public class Role:IdentityRole
    {
        public ICollection<User> Users { get; set; }

    }
}