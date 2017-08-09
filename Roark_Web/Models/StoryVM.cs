using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roark_Web.Models
{
    public class StoryVM
    {
        public int StoryId { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public bool IsPublished { get; set; }
        public Genre Genre { get; set; }
        public bool HasRudewords { get; set; }
        public IEnumerable<User> Authors { get; set; }
        public int StoryPartCount { get; set; }
        public string Description { get; set; }
        public string PartialContent { get; set; }
        public float AverageScore { get; set; }
        public int RatingCount { get; set; }
    }
}