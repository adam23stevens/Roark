using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    public interface IRoarkContext 
    {
        DbSet<Story> Stories { get; set; }
        DbSet<StoryPart> StoryParts { get; set; }
        DbSet<Keyword> Keywords { get; set; }
        DbSet<KeywordType> KeywordTypes { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Rating> Ratings { get; set; }

        DbContextTransaction DbContextTransaction { get; set; }
        void SetModified(object entity);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
