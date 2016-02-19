namespace JustTweet.Services.Data
{
    using System;
    using System.Linq;
    using JustTweet.Services.Data.Contracts;
    using JustTweet.Data.Repositories;
    using JustTweet.Data.Models;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;
        private IRepository<Rating> ratings;

        public UsersService(IRepository<User> users, IRepository<Rating> ratings)
        {
            this.users = users;
            this.ratings = ratings;
        }

        public void Rate(string UserId, int value)
        {
            var newRating = new Rating
            {
                UserId = UserId,
                Value = value
            };

            this.ratings.Add(newRating);
            this.ratings.SaveChanges();
        }

        public User GetByUsername(string username)
        {
            return this.users.All().Where(u => u.UserName == username).FirstOrDefault();
        }
    }
}
