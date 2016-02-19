namespace JustTweet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
