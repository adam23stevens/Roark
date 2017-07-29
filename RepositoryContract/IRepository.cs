using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace RepositoryContract
{
    public interface IRepository
    {
        IEnumerable<Story> GetAllStories();
        Story GetStory(int StoryId);
        IEnumerable<Story> GetUserStories(int StoryId);

        IEnumerable<StoryPart> GetStoryParts(int StoryId);
        StoryPart GetStoryPart(int StoryId, int OrderNum);
        IEnumerable<StoryPart> GetUserStoryParts(int UserId);

        IEnumerable<Rating> GetUserRatings(int UserId);
        IEnumerable<Rating> GetStoryRatings(int StoryId);
        Rating GetRating(int RatingId);

        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetStoryUsers(int StoryId);
        User Getuser(int UserId);

        IEnumerable<Genre> GetAllGenres();
        Genre GetStoryGenre(int StoryId);
        Genre GetGenre(string GenreId);

        IEnumerable<Keyword> GetGenreKeywords(string GenreId, string KeywordTypeId = "");
        IEnumerable<KeywordType> GetAllKeywordTypes();

        IEnumerable<Rudewords> GetAllRudewords();
    }
}
