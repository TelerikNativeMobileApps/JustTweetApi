namespace JustTweet.Web.Api.Controllers
{
    using System.Web.Http;
    using Models;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public class TweetsController : ApiController
    {
        private ITweetsService tweets;

        public TweetsController(ITweetsService tweets)
        {
            this.tweets = tweets;
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]int page = 1)
        {
            var result = this.tweets.GetByPage(page).ProjectTo<TweetResponseModel>().ToList();

            return this.Ok(result);
        }
        
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(TweetRequestModel tweet)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Tweet length must be between 10 and 300");
            }

            this.tweets.Add(this.User.Identity.GetUserId(), tweet.Text);

            return this.Ok();
        }
    }
}
