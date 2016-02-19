namespace JustTweet.Web.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RatingRequestModel
    {
        public string UserId { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}