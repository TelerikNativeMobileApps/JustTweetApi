namespace JustTweet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class JustTweet
    {
        private ICollection<Comment> comments;

        public JustTweet()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Range(1800, int.MaxValue)]
        public int ConstructionYear { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string Address { get; set; }

        [MinLength(10)]
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? SellingPrice { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? RentingPrice { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public JustTweetType JustTweetType { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Contact { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}
