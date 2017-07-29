using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class StoryPart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoryPartId { get; set; }
        public int Order { get; set; }
        public string Content { get; set; }
        public IEnumerable<Keyword> RequiredKeywords { get; set; }

        public int StoryId { get; set; }
        [ForeignKey("StoryId")]
        public virtual Story Story { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }        
    }
}