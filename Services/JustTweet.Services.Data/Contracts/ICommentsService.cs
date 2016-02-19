namespace JustTweet.Services.Data.Contracts
{
    using System.Linq;
    using JustTweet.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> Get(int id, int skip = 0, int take = 10);

        IQueryable<Comment> GetByUser(string username, int skip = 0, int take = 10);

        Comment Add(int estateId, string content, string userId);
    }
}
