namespace JustTweet.Services.Data
{
    using System;
    using System.Linq;
    using JustTweet.Services.Data.Contracts;
    using JustTweet.Data.Models;
    using JustTweet.Data.Repositories;

    public class CommentsService : ICommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment Add(int estateId, string content, string userId)
        {
            var newComment = new Comment
            {
                CreatedOn = DateTime.UtcNow,
                Content = content,
                UserId = userId,
                JustTweetId = estateId
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            // I have no idea why username is null
            return this.comments.GetById(newComment.Id);
        }

        public IQueryable<Comment> Get(int id, int skip = 0, int take = 10)
        {
            return this.comments
                            .All()
                            .Where(c => c.JustTweet.Id == id)
                            .OrderBy(c => c.CreatedOn)
                            .Skip(skip)
                            .Take(take);
        }

        public IQueryable<Comment> GetByUser(string username, int skip = 0, int take = 10)
        {
            return this.comments
                            .All()
                            .Where(c => c.User.UserName == username)
                            .OrderBy(c => c.CreatedOn)
                            .Skip(skip)
                            .Take(take);
        }
    }
}
