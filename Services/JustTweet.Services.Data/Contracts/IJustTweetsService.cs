namespace JustTweet.Services.Data.Contracts
{
    using System.Linq;
    using JustTweet.Data.Models;

    public interface IJustTweetsService
    {
        JustTweet Add(
            string title,
            string description,
            string address,
            string contact,
            int constructionYear,
            decimal? sellingPrice,
            decimal? rentingPrice,
            int type,
            string userID);

        IQueryable<JustTweet> Get(int skip = 0, int take = 10);

        JustTweet GetDetails(int id);
    }
}
