#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class InterviewComment
    {
        // Required by entity framework
        public InterviewComment() { }

        public InterviewComment(string message, DateTime issued, User user, long interviewId)
        {
            Message = message;
            Issued = issued;
            User = user;
            InterviewId = interviewId;
        }

        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime Issued { get; set; }
        public User User { get; set; }
        public long InterviewId { get; set; }
        public Interview Interview { get; set; }
    }
}