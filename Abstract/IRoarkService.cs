using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IRoarkService
    {
        string OutputStoryContent(int StoryId);

        float GenerateAverageStoryReview(int StoryId);

        void CreateStory(string title, Genre genre, int MaxUsers);

        void AddStoryPart(Story story, User user, string content, int order);

        IEnumerable<Story> GetUserStories(int userId);
    }
}
