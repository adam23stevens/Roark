using Abstract;
using System;
using System.Collections.Generic;
using RepositoryContract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Concrete
{
    public class RoarkService : IRoarkService
    {
        private IRepository _repository;

        public RoarkService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddStoryPart(Story story, User user, string content, int order)
        {
            var nextStoryPart = new StoryPart
            {
                Content = TrimStoryContent(content),
                Order = order,
                StoryId = story.Id,
                UserId = user.UserId,
                RequiredKeywords = GetKeyword(story, order)
            };

            _repository.AddStoryPart(nextStoryPart);
        }

        private IEnumerable<Keyword> GetKeyword(Story story, int order)
        {
            var keywords = _repository.GetGenreKeywords(story.GenreId);

            return keywords.Count() >= order ? keywords.Skip(order - 1).Take(1) : keywords.Skip(0).Take(1);
        }

        private string TrimStoryContent(string prevContent)
        {
            string retContent = "";
            if (prevContent.Length > 0)
            {
                var split = prevContent.Split(' ');

                //TODO make this programmatic and loop based on a number of previous words to pass in
                retContent = $"{split[split.Length - 2]} {split[split.Length - 1]}"; 
            }

            return retContent;
        }

        public void CreateStory(string title, Genre genre, int MaxUsers)
        {
            var story = new Story
            {
                Title = title,
                Genre = genre,
                MaxUsers = MaxUsers
            };

            _repository.AddStory(story);
        }

        public float GenerateAverageStoryReview(int StoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetUserStories(int userId)
        {
            throw new NotImplementedException();
        }

        public string OutputStoryContent(int StoryId)
        {
            throw new NotImplementedException();
        }
    }
}
