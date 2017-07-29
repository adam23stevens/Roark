using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Story
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int MaxUsers { get; set; }
        public bool HasRudewords { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        
        public bool IsPublished { get; set; }
        public virtual ICollection<StoryPart> StoryParts { get; set; }

        public virtual string GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
