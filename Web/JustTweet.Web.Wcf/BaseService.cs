namespace JustTweet.Web.Wcf
{
    using Data.Models;
    using JustTweet.Data.Repositories;
    using Data;

    public abstract class BaseService
    {
        protected BaseService()
        {
            var db = new JustTweetDbContext();
            this.Users = new EfGenericRepository<User>(db);
        }

        protected IRepository<User> Users { get; private set; }
    }
}