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

        public void AddRating(Rating rating)
        {
            try
            {
                _ctx.BeginTransaction();
                _ctx.Ratings.Add(rating);
                _ctx.SetModified(rating);
                _ctx.CommitTransaction();
            }
            catch
            {
                _ctx.RollbackTransaction();
                throw;
            }
        }

        public void AddStory(Story story)
        {
            try
            {
                _ctx.BeginTransaction();
                _ctx.Stories.Add(story);
                _ctx.SetModified(story);
                _ctx.CommitTransaction();
            }
            catch
            {
                _ctx.RollbackTransaction();
                throw;
            }
        }

        public void AddStoryPart(StoryPart storyPart)
        {
            try
            {
                _ctx.BeginTransaction();
                _ctx.StoryParts.Add(storyPart);
                _ctx.SetModified(storyPart);
                _ctx.CommitTransaction();
            }
            catch
            {
                _ctx.RollbackTransaction();
                throw;
            }
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _ctx.Genres;
        }

        public IEnumerable<KeywordType> GetAllKeywordTypes()
        {
            return _ctx.KeywordTypes;
        }

        public IEnumerable<Rudewords> GetAllRudewords()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetAllStories()
        {
            return _ctx.Stories;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }

        public Genre GetGenre(string GenreId)
        {
            var genre = _ctx.Genres.First(g => g.Id == GenreId);
            return genre;
        }

        public IEnumerable<Keyword> GetGenreKeywords(string GenreId, string KeywordTypeId = "")
        {
            IQueryable<Keyword> keywords = _ctx.Keywords.Where(k => k.GenreId == GenreId);
            keywords = KeywordTypeId.Length > 0 ? keywords.Where(k => k.KeywordTypeId == KeywordTypeId) : keywords;

            return keywords as IEnumerable<Keyword>;
        }

        public Rating GetRating(int RatingId)
        {
            var rating = _ctx.Ratings.First(r => r.Id == RatingId);

            return rating;
        }

        public Story GetStory(int StoryId)
        {
            var story = _ctx.Stories.First(s => s.Id == StoryId);

            return story;
        }

        public IEnumerable<StoryPart> GetStoryParts(int StoryId)
        {
            IQueryable<StoryPart> storyParts = _ctx.StoryParts.Where(s => s.StoryId == StoryId);

            return storyParts as IEnumerable<StoryPart>;
        }

        public IEnumerable<Rating> GetStoryRatings(int StoryId)
        {
            IQueryable<Rating> ratings = _ctx.Ratings.Where(r => r.StoryId == StoryId);

            return ratings as IEnumerable<Rating>;
        }

        public IEnumerable<User> GetStoryUsers(int StoryId)
        {
            var users = _ctx.StoryParts.Where(sp => sp.StoryId == StoryId)
                                       .Select(sp => sp.User);

            return users;
        }

        public User Getuser(int UserId)
        {
            var user = _ctx.Users.First(u => u.UserId == UserId);

            return user;
        }

        public IEnumerable<Rating> GetUserRatings(int UserId)
        {
            IQueryable<Rating> ratings = _ctx.Ratings.Where(r => r.UserId == UserId);

            return ratings as IEnumerable<Rating>;
        }

        public IEnumerable<Story> GetUserStories(int UserId)
        {
            IQueryable<StoryPart> storyParts = _ctx.StoryParts.Where(sp => sp.UserId == UserId);

            var stories = storyParts.Select(sp => sp.Story);

            return stories;
        }

        public IEnumerable<StoryPart> GetUserStoryParts(int StoryId, int UserId)
        {
            var story = GetStory(StoryId);
            IQueryable<StoryPart> storyParts = _ctx.StoryParts.Where(sp => sp.StoryId == StoryId)
                                                              .Where(sp => sp.UserId == UserId);

            return storyParts as IEnumerable<StoryPart>;
        }
    }
}
