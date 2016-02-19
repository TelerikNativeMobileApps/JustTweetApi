namespace JustTweet.Web.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TweetRequestModel
    {
        [MinLength(10)]
        [MaxLength(300)]
        [Required]
        public string Text { get; set; }
    }
}