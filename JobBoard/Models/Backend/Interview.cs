#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class Interview
    {
        /**/
        public Interview() { }
        public Interview(long companyId, Company company, int difficulty, string position, string comment, Tag tag, DateTime issued)
        {
            CompanyId = companyId;
            Company = company;
            Difficulty = difficulty;
            Position = position;
            Comment = comment;
            Tag = tag;
            Issued = issued;
        }
        /*
        public Interview(long id, long companyId, Company company, int difficulty, string position, string comment, Tag tag, DateTime issued)
        {
            Id = id;
            CompanyId = companyId;
            Company = company;
            Difficulty = difficulty;
            Position = position;
            Comment = comment;
            Tag = tag;
            Issued = issued;
        }
        */

        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public int Difficulty { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public Tag Tag { get; set; }
        public DateTime Issued { get; set; }
    }
}