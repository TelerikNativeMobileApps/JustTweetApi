namespace JustTweet.Web.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class JustTweetRequestModel
    {
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MinLength(10)]
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Range(1800, int.MaxValue)]
        public int ConstructionYear { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? SellingPrice { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? RentingPrice { get; set; }

        public int Type { get; set; }
    }
}