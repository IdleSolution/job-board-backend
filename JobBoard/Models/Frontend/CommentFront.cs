#nullable enable

using System;

namespace JobBoard.Models.Frontend
{
    public class CommentFront
    {
        public CommentFront(long id, string message, DateTime issued, string creatorEmail)
        {
            Id = id;
            Message = message;
            Issued = issued;
            CreatorEmail = creatorEmail;
        }

        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Issued { get; set; }
        public string CreatorEmail { get; set; }
    }
}