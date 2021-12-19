#nullable enable

using System.Collections.Generic;

namespace JobBoard.Models.Frontend
{
    public class CompanyFront
    {
        public CompanyFront(string name, int reviewCount, double rating, int interviewCount, double difficulty, ICollection<string> tags)
        {
            Name = name;
            ReviewCount = reviewCount;
            Rating = rating;
            InterviewCount = interviewCount;
            Difficulty = difficulty;
            Tags = tags;
        }

        public string Name { get; set; }
        public int ReviewCount { get; set; }
        public double Rating { get; set; }
        public int InterviewCount { get; set; }
        public double Difficulty { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}