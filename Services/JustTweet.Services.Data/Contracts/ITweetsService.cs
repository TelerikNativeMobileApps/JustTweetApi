namespace JustTweet.Services.Data.Contracts
{
    using System.Linq;
    using JustTweet.Data.Models;

    public interface ITweetsService
    {
        IQueryable<Tweet> GetByPage(int page);

        void Add(string userId, string text);
    }
}
