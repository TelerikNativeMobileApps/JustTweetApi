namespace JustTweet.Web.Api.Controllers
{
    using System.Web.Http;
    using Models;
    using Infrastructure.Validation;
    using Services.Data.Contracts;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public class JustTweetsController : ApiController
    {
        private IJustTweetsService realEstates;

        public JustTweetsController(IJustTweetsService realEstates)
        {
            this.realEstates = realEstates;
        }

        [HttpGet]
        public IHttpActionResult GetPublicEstates([FromUri]int skip = 0, int take = 10)
        {
            if (take > 100)
            {
                return this.BadRequest("Real estates per page cannot be more than 100");
            }

            var result = this.realEstates.Get(skip, take).ProjectTo<JustTweetResponseModel>().ToList();

            return this.Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetDetails(int id)
        {
            var result = this.realEstates.GetDetails(id);

            if (Request.Headers.Authorization == null)
            {
                return this.Ok(Mapper.Map<JustTweetDetailsPublicReponseModel>(result));
            }

            return this.Ok(Mapper.Map<JustTweetDetailsPrivateReponseModel>(result));
        }

        [ValidateModel]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(JustTweetRequestModel realEstate)
        {
            var result = this.realEstates.Add(
                                        realEstate.Title,
                                        realEstate.Description,
                                        realEstate.Address,
                                        realEstate.Contact,
                                        realEstate.ConstructionYear,
                                        realEstate.SellingPrice,
                                        realEstate.RentingPrice,
                                        realEstate.Type,
                                        this.User.Identity.GetUserId());

            return this.Created(string.Format("api/JustTweets/{0}", result.Id), Mapper.Map<JustTweetResponseModel>(result));
        }
    }
}
