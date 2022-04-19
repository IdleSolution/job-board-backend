#nullable enable

using System;
using System.Collections.Generic;

namespace JobBoard.Models.Frontend
{
    public class ReviewFront
    {
        public ReviewFront(long id, int rating, string position, string comment, string tag, DateTime? from, DateTime? to, bool isStillWorking, DateTime issued, string creatorEmail)
        {
            Id = id;
            Rating = rating;
            Position = position;
            Comment = comment;
            Tag = tag;
            From = from;
            To = to;
            IsStillWorking = isStillWorking;
            Issued = issued;
            CreatorEmail = creatorEmail;
        }
        public long Id { get; set; }
        public int Rating { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool IsStillWorking { get; set; }
        public DateTime Issued { get; set; }
        public string CreatorEmail { get; set; }
    }
}