namespace JustTweet.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class JustTweetDbContext : IdentityDbContext<User>
    {
        public JustTweetDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static JustTweetDbContext Create()
        {
            return new JustTweetDbContext();
        }
    }
}
