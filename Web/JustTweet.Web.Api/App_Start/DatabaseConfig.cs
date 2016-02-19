namespace JustTweet.Web.Api
{
    using System.Data.Entity;
    using JustTweet.Data;
    using JustTweet.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JustTweetDbContext, Configuration>());
        }
    }
}