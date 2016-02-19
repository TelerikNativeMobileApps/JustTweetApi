namespace JustTweet.Web.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentRequestModel
    {
        public int JustTweetId { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}