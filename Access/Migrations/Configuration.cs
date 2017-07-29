namespace Access.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Access.RoarkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void RunSqlCommand<T>(Action<RoarkContext> cmd, RoarkContext ctx)
        {
            try
            {
                ctx.BeginTransaction();
                cmd(ctx);
                ctx.CommitTransaction();
            }
            catch
            {
                ctx.RollbackTransaction();
            }
        }

        protected override void Seed(Access.RoarkContext context)
        {
            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Genres.AddOrUpdate(new Genre
            {
                Id = "HOR",
                Name = "Horror"
            }, new Genre
            {
                Id = "FAN",
                Name = "Fantasy"
            }, new Genre
            {
                Id = "CRI",
                Name = "Crime"
            }, new Genre
            {
                Id = "ROM",
                Name = "Romantic"
            }, new Genre
            {
                Id = "ADV",
                Name = "Adventure"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.KeywordTypes.AddOrUpdate(new KeywordType
            {
                Id = "NOUN",
                Value = 5
            }, new KeywordType
            {
                Id = "VERB",
                Value = 5
            },new KeywordType
            {
                Id = "ADJECTIVE",
                Value = 5
            }), context);            

            var nounKeywordType = context.KeywordTypes.FirstOrDefault(k => k.Id == "NOUN").Id;
            var verbKeywordType = context.KeywordTypes.FirstOrDefault(k => k.Id == "VERB").Id;
            var adjKeywordType = context.KeywordTypes.FirstOrDefault(k => k.Id == "ADJECTIVE").Id;

            //Horror start
            var horrorGenreId = context.Genres.FirstOrDefault(g => g.Id == "HOR").Id;
            

            var horrorNouns = new List<string>
            {
                "evil","clown","creak","laughter","basement"
            };
            var horrorVerbs = new List<string>
            {
                "run", "creak", "snap", "cry", "block"
            };
            var horrorAdjectives = new List<string>
            {
                "slimy", "red", "dark", "cold", "humid"
            };

            AddKeywords(context, horrorNouns, horrorGenreId, nounKeywordType);
            AddKeywords(context, horrorVerbs, horrorGenreId, verbKeywordType);
            AddKeywords(context, horrorAdjectives, horrorGenreId, adjKeywordType);

            //Fantasy start

            var fantasyGenreId = context.Genres.FirstOrDefault(g => g.Id == "FAN").Id;

            var fantasyNouns = new List<string>
            {
                "witch", "spell", "horse", "war", "dust"
            };
            var fantasyVerbs = new List<string>
            {
                "cast", "swing", "shine", "discover", "wander"
            };
            var fantasyAdjectives = new List<string>
            {
                "high", "shiny", "intimidating", "young", "reflective"
            };

            AddKeywords(context, fantasyNouns, fantasyGenreId, nounKeywordType);
            AddKeywords(context, fantasyVerbs, fantasyGenreId, verbKeywordType);
            AddKeywords(context, fantasyAdjectives, fantasyGenreId, adjKeywordType);            

            //Romantic start

            var romanceGenreid = context.Genres.FirstOrDefault(g => g.Id == "ROM").Id;

            var romanceNouns = new List<string>
            {
                "walk", "discovery", "embrace", "mystery", "life"
            };
            var romanceVerbs = new List<string>
            {
                "encounter", "brief", "converse", "kiss", "touch"
            };
            var romanceAdjectives = new List<string>
            {
                "cold", "close", "distant","happy", "upset"
            };

            AddKeywords(context, romanceNouns, romanceGenreid, nounKeywordType);
            AddKeywords(context, romanceVerbs, romanceGenreid, verbKeywordType);
            AddKeywords(context, romanceAdjectives, romanceGenreid, adjKeywordType);            

            //Adventure start
            var adventureGenreId = context.Genres.FirstOrDefault(g => g.Id == "ADV").Id;

            var adventureNouns = new List<string>
            {
                "island", "pirate", "sky", "cave", "bear"
            };
            var adventureVerbs = new List<string>
            {
                "attack", "sneak", "capture", "thwart", "slide"
            };
            var adventureAdjectives = new List<string>
            {
                "bold", "scared", "tired", "lonely", "brave"
            };

            AddKeywords(context, adventureNouns, adventureGenreId, nounKeywordType);
            AddKeywords(context, adventureVerbs, adventureGenreId, verbKeywordType);
            AddKeywords(context, adventureAdjectives, adventureGenreId, adjKeywordType);

            //Users
            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Users.AddOrUpdate(new User
            {
                Forename = "Adam",
                Surname = "Stevens",
                Email = "adam23stevens@gmail.com",
                Password = "password123",
                CurrentScore = 0
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Users.AddOrUpdate(new User
            {
                Forename = "Julia",
                Surname = "Rogers",
                Email = "jrogers@live.co.uk",
                Password = "password123",
                CurrentScore = 0
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Users.AddOrUpdate(new User
            {
                Forename = "James",
                Surname = "Ovenden",
                Email = "jovenden@gmail.com",
                Password = "password123",
                CurrentScore = 0
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Stories.AddOrUpdate(new Story
            {
                GenreId = context.Genres.FirstOrDefault(g => g.Id == "HOR").Id,
                IsActive = true,
                HasRudewords = true,
                IsPublished = false,
                MaxUsers = 3,
                Title = "First horror"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "adam23stevens@gmail.com").UserId,
                Order = 0,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "NOUN").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Take(1),
                Content = @"Now this is a story about an evil warlord who"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "jrogers@live.co.uk").UserId,
                Order = 1,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "NOUN").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Skip(1).Take(1),
                Content = @"decided he wanted to make friends with the local clown."
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "jovenden@gmail.com").UserId,
                Order = 2,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "NOUN").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Skip(2).Take(1),
                Content = @"The clown noticed him sneaking by as he heard the floorboards creak"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "adam23stevens@gmail.com").UserId,
                Order = 3,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "VERB").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Skip(3).Take(1),
                Content = @"at which point the warlord knew he had to run away"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "jrogers@live.co.uk").UserId,
                Order = 4,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "VERB").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Skip(4).Take(1),
                Content = @"back to his house which made the floorboards creak again when suddenly"
            }), context);

            RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.StoryParts.AddOrUpdate(new StoryPart
            {
                StoryId = context.Stories.FirstOrDefault(s => s.Title == "First horror").Id,
                UserId = context.Users.FirstOrDefault(u => u.Email == "jovenden@gmail.com").UserId,
                Order = 5,
                RequiredKeywords = context.Keywords.Where(
                    k => k.KeywordTypeId == context.KeywordTypes.FirstOrDefault(kt => kt.Id == "VERB").Id &&
                         k.GenreId == context.Genres.FirstOrDefault(g => g.Id == "HOR").Id).Skip(5).Take(1),
                Content = @"he fell and broke his neck with an awful load snap sound."
            }), context);

        }

        private void AddKeywords(RoarkContext context, List<string> keywords, string genreId, string keywordTypeId)
        {
            keywords.ForEach(k =>
            {
                if (!context.Keywords.Any(n => n.Word == k && n.GenreId == genreId && n.KeywordTypeId == keywordTypeId))
                {
                    RunSqlCommand<RoarkContext>((RoarkContext ctx) => context.Keywords.AddOrUpdate(
                        new Keyword
                        {
                            GenreId = genreId,
                            KeywordTypeId = keywordTypeId,
                            Word = k
                        }),context);
                }
            });
        }
    }
}
