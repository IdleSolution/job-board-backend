#nullable enable

using System;
using System.Collections.Generic;

namespace JobBoard.Models.Frontend
{
    public class UserFront
    {
        public UserFront(string email, string userName, ICollection<ReviewFront> reviews, ICollection<InterviewFront> interviews)
        {
            Email = email;
            UserName = userName;
            Reviews = reviews;
            Interviews = interviews;
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<ReviewFront> Reviews { get; set; }
        public ICollection<InterviewFront> Interviews { get; set; }

    }
}