using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Access;

namespace Repository
{
    public class RoarkRepository : IRepository
    {
        private IRoarkContext _ctx;
        public RoarkRepository(IRoarkContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<Genre> GetAllGenres()
        {
            return _ctx.Genres;
        }

        public IEnumerable<KeywordType> GetAllKeywordTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rudewords> GetAllRudewords()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetAllStories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Genre GetGenre(string GenreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Keyword> GetGenreKeywords(string GenreId, string KeywordTypeId = "")
        {
            throw new NotImplementedException();
        }

        public Rating GetRating(int RatingId)
        {
            throw new NotImplementedException();
        }

        public Story GetStory(int StoryId)
        {
            throw new NotImplementedException();
        }

        public Genre GetStoryGenre(int StoryId)
        {
            throw new NotImplementedException();
        }

        public StoryPart GetStoryPart(int StoryId, int OrderNum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoryPart> GetStoryParts(int StoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetStoryRatings(int StoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetStoryUsers(int StoryId)
        {
            throw new NotImplementedException();
        }

        public User Getuser(int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetUserRatings(int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetUserStories(int StoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoryPart> GetUserStoryParts(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
