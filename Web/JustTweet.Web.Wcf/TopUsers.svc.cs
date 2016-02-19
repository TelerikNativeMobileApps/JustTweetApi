namespace JustTweet.Web.Wcf
{
    using System.Collections.Generic;
    using JustTweet.Web.Wcf.Models;
    using System.Linq;

    public class TopUsers : BaseService, ITopUsers
    {
        public IEnumerable<UserDetailsResponseModel> Get(string page)
        {
            return this.Users.All().Select(u => new UserDetailsResponseModel
            {
                UserName = u.UserName,
                Rating = (double)u.Ratings.Sum(r => r.Value) / u.Ratings.Count
            })
            .OrderBy(u => u.Rating)
            .Take(10);
        }
    }
}
