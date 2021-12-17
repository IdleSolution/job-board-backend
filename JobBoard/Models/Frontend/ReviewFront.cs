#nullable enable

using System;

namespace JobBoard.Models.Frontend
{
    public class ReviewFront
    {
        public int Rating { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime Issued { get; set; }
    }
}