#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class Review
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public int Rating { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public Tag Tag { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime Issued { get; set; }
    }
}