namespace JustTweet.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Validation;
    using Models;
    using JustTweet.Services.Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class CommentsController : ApiController
    {
        private ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        [Route("api/Comments/ByUser/{username}")]
        [Authorize]
        [ValidateModel]
        public IHttpActionResult GetByUser(string username = "pesho", int skip = 0, int take = 10)
        {
            if (take > 100 || take < 0 || skip < 0)
            {
                return this.BadRequest("Comments per page cannot be more than 100");
            }

            var result = this.comments.GetByUser(username, skip, take).ProjectTo<CommentResponseModel>().ToList();

            return this.Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/Comments/{id}")]
        public IHttpActionResult GetByEstate(int id,[FromUri]int skip = 0, int take = 10)
        {
            if (take > 100)
            {
                return this.BadRequest("Comments per page cannot be more than 100");
            }

            var result = this.comments.Get(id, skip, take).ProjectTo<CommentResponseModel>().ToList();

            return this.Ok(result);
        }

        [ValidateModel]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(CommentRequestModel comment)
        {
            var result = this.comments.Add(comment.JustTweetId, comment.Content, this.User.Identity.GetUserId());

            return this.Created(string.Format("api/Comments/{0}", result.Id), Mapper.Map<CommentResponseModel>(result));
        }
    }
}
