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
        public Genre Genre { get; set; }
        public bool IsActive { get; set; }
        public List<User> CurrentUsers { get; set; }
        public int MaxUsers { get; set; }
        public List<StoryPart> StoryParts { get; set; }
        public bool HasRudewords { get; set; }
        public List<Rating> Ratings { get; set; }
        public float AverageScore { get; set; } //vm
        public bool IsPublished { get; set; }
    }
}
