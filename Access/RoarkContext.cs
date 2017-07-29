using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    public class RoarkContext: DbContext, IRoarkContext
    {
        public DbSet<Genre> Genres { get; set; }

        public DbSet<KeywordType> KeywordTypes { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<StoryPart> StoryParts { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbContextTransaction DbContextTransaction { get; set; }

        public void BeginTransaction()
        {
            if (DbContextTransaction == null)
            {
                DbContextTransaction = Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (DbContextTransaction != null)
                {
                    DbContextTransaction.Commit();
                }
            }
            catch
            {
                RollbackTransaction();
            }
            finally
            {
                DbContextTransaction = null;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                if (DbContextTransaction?.UnderlyingTransaction != null)
                {
                    DbContextTransaction.Rollback();
                }
            }
            finally
            {
                DbContextTransaction = null;
            }
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
