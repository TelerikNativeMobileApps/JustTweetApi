namespace JustTweet.Web.Api.Models
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using JustTweet.Web.Api.Infrastructure.Mappings;

    public class JustTweetDetailsPrivateReponseModel : IMapFrom<JustTweet>, IHaveCustomMappings
    {
        public string Contact { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ConstructionYear { get; set; }

        public string Address { get; set; }

        public string JustTweetType { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<JustTweet, JustTweetDetailsPrivateReponseModel>()
                .ForMember(e => e.JustTweetType, opts => opts.MapFrom(e => e.JustTweetType.ToString()));
        }
    }
}