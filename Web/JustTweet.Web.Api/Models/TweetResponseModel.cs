namespace JustTweet.Web.Api.Models
{
    using AutoMapper;
    using Data.Models;
    using JustTweet.Web.Api.Infrastructure.Mappings;

    public class TweetResponseModel : IMapFrom<Tweet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string CreatedOn { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tweet, TweetResponseModel>()
                .ForMember(c => c.Author, opts => opts.MapFrom(c => c.User.UserName));
        }
    }
}