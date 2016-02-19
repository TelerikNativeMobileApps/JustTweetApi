namespace JustTweet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int JustTweetId { get; set; }

        public virtual JustTweet JustTweet { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
