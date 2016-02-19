namespace JustTweet.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Range(1,5)]
        public int Value { get; set; }
    }
}
