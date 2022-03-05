#nullable enable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Backend
{
    public class Tag
    {
        public Tag() { }

        public Tag(string name)
        {
            Name = name;
        }

        [Key]
        [ForeignKey("Interview")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}