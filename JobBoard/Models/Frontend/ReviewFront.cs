#nullable enable

using System;

namespace JobBoard.Models.Frontend
{
    public class ReviewFront
    {
        public ReviewFront(int rating, string position, string comment, string tag, DateTime? from, DateTime? to, DateTime issued)
        {
            Rating = rating;
            Position = position;
            Comment = comment;
            Tag = tag;
            From = from;
            To = to;
            Issued = issued;
        }

        public int Rating { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime Issued { get; set; }
    }
}