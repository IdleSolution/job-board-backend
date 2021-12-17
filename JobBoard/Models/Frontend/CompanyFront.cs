#nullable enable

using System.Collections.Generic;

namespace JobBoard.Models.Frontend
{
    public class CompanyFront
    {
        public CompanyFront(string name, int reviewCount, double rating, ICollection<string> tags)
        {
            Name = name;
            ReviewCount = reviewCount;
            Rating = rating;
            Tags = tags;
        }

        public string Name { get; set; }
        public int ReviewCount { get; set; }
        public double Rating { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}