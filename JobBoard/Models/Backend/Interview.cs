#nullable enable

using System;

namespace JobBoard.Models.Backend
{
    public class Interview
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public int Difficulty { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public string Tag { get; set; }
        public DateTime Issued { get; set; }
    }
}