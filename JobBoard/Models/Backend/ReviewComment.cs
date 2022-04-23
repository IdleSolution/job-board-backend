#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class ReviewComment
    {
        // Required by entity framework
        public ReviewComment() { }

        public ReviewComment(string message, DateTime issued, User user, Review review)
        {
            Message = message;
            Issued = issued;
            User = user;
            Review = review;
        }

        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Issued { get; set; }
        public User User { get; set; }
        public Review Review { get; set; }
    }
}