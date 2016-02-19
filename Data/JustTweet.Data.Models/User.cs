namespace JustTweet.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<JustTweet> realEstates;
        private ICollection<Rating> ratings;

        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.JustTweets = new HashSet<JustTweet>();
            this.Ratings = new HashSet<Rating>();
        }

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

        public virtual ICollection<JustTweet> JustTweets
        {
            get
            {
                return this.realEstates;
            }

            set
            {
                this.realEstates = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }

            set
            {
                this.ratings = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
