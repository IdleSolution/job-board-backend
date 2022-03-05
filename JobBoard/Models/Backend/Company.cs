#nullable enable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Backend
{
    public class Company
    {
        public Company() { }
        public Company(string name)
        {
            Name = name;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }
}