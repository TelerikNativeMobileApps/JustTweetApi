namespace JustTweet.Web.Api.Models
{
    using AutoMapper;
    using JustTweet.Web.Api.Infrastructure.Mappings;
    using JustTweet.Data.Models;
    using System.Linq;

    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int JustTweets { get; set; }

        public int Comments { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserResponseModel>()
                .ForMember(u => u.JustTweets, opts => opts.MapFrom(u => u.JustTweets.Count))
                .ForMember(u => u.Comments, opts => opts.MapFrom(u => u.Comments.Count))
                .ForMember(u => u.Rating, opts => opts.MapFrom(u => (double)u.Ratings.Sum(r => r.Value) / u.Ratings.Count));
        }
    }
}