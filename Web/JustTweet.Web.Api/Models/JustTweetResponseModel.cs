namespace JustTweet.Web.Api.Models
{
    using Data.Models;
    using JustTweet.Web.Api.Infrastructure.Mappings;

    public class JustTweetResponseModel : IMapFrom<JustTweet>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }
    }
}