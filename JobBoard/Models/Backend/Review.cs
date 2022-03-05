#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class Review
    {
        // Required by entity framework
        public Review() { }

        public Review(long companyId, Company company, int rating, string position, string comment, Tag tag, DateTime? from, DateTime? to, DateTime issued)
        {
            CompanyId = companyId;
            Company = company;
            Rating = rating;
            Position = position;
            Comment = comment;
            Tag = tag;
            From = from;
            To = to;
            Issued = issued;
        }

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