using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Genre
    {
        [Key]       
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}