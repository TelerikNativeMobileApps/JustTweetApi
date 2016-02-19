namespace JustTweet.Services.Data
{
    using JustTweet.Services.Data.Contracts;
    using JustTweet.Data.Repositories;
    using JustTweet.Data.Models;
    using System;
    using System.Linq;

    public class TweetsService : ITweetsService
    {
        private IRepository<Tweet> tweets;
        private const int PageSize = 10;

        public TweetsService(IRepository<Tweet> tweets)
        {
            this.tweets = tweets;
        }

        public void Add(string userId, string text)
        {
            var newTweet = new Tweet
            {
                UserId = userId,
                Text = text
            };

            this.tweets.Add(newTweet);
            this.tweets.SaveChanges();
        }

        public IQueryable<Tweet> GetByPage(int page)
        {
            return this.tweets.All()
                .OrderBy(t => t.CreatedOn)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
        }
    }
}
