namespace JustTweet.Web.Wcf
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using JustTweet.Web.Wcf.Models;

    [ServiceContract]
    public interface ITopUsers
    {
        [OperationContract]
        IEnumerable<UserDetailsResponseModel> Get(string page);
    }
}
