namespace JustTweet.Services.Data.Contracts
{
    using JustTweet.Data.Models;

    public interface IUsersService
    {
        void Rate(string UserId, int value);

        User GetByUsername(string username);
    }
}
