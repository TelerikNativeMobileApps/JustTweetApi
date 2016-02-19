namespace JustTweet.Web.Api.Controllers
{
    using System.Web.Http;
    using AutoMapper;
    using Infrastructure.Validation;
    using Models;
    using Services.Data.Contracts;

    public class UsersController : ApiController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [Route("api/Users/{username}")]
        public IHttpActionResult Get(string username)
        {
            var result = this.users.GetByUsername(username);

            return this.Ok(Mapper.Map<UserResponseModel>(result));
        }

        [HttpPut]
        [Authorize]
        [Route("api/Users/Rate")]
        [ValidateModel]
        public IHttpActionResult RateUser(RatingRequestModel rating)
        {
            this.users.Rate(rating.UserId, rating.Value);

            return this.Ok();
        }
    }
}
