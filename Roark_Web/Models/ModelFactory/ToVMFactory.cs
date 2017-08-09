using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roark_Web.Models.ModelFactory
{
    public static class ToVMFactory
    {
        public static StoryVM ToStoryVM(Story Story)
        {
            StoryVM storyVM = new StoryVM
            {
                Title = Story.Title,
                Authors = Story.StoryParts.Select(sp => sp.User).Distinct(),
                Genre = Story.Genre, //need to actually use repo to get this via story.GenreId
                StoryPartCount = Story.StoryParts.Count,
                IsPublished = Story.IsPublished,
                RatingCount = Story.Ratings.Count,
                AverageScore = Story.Ratings.Sum(r => r.Score) / Story.Ratings.Count,
                HasRudewords = Story.HasRudewords,
                PartialContent = Story.StoryParts.First().Content //just taking all of the first for now
            };

            return storyVM;
        }
    }
}