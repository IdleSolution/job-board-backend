#nullable enable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Frontend
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}