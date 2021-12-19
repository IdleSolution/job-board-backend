#nullable enable

using JobBoard.Models.Backend;
using System;

namespace JobBoard.Models.Frontend
{
    public class InterviewFront
    {
        public InterviewFront(int difficulty, string position, string comment, string tag, DateTime issued)
        {
            Difficulty = difficulty;
            Position = position;
            Comment = comment;
            Tag = tag;
            Issued = issued;
        }

        public int Difficulty { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public DateTime Issued { get; set; }
    }
}