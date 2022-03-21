#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class Interview
    {
        // Required by entity framework
        public Interview() { }
        public Interview(long companyId, Company company, int difficulty, string position, string comment, Tag tag, DateTime issued, User user)
        {
            CompanyId = companyId;
            Company = company;
            Difficulty = difficulty;
            Position = position;
            Comment = comment;
            Tag = tag;
            Issued = issued;
            User = user;
        }

        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public int Difficulty { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public Tag Tag { get; set; }
        public DateTime Issued { get; set; }
        public User User { get; set; }
    }
}