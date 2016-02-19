namespace JustTweet.Services.Data
{
    using System;
    using JustTweet.Data.Models;
    using JustTweet.Services.Data.Contracts;
    using JustTweet.Data.Repositories;
    using System.Linq;

    public class JustTweetsService : IJustTweetsService
    {
        private IRepository<JustTweet> realEstates;

        public JustTweetsService(IRepository<JustTweet> realEstates)
        {
            this.realEstates = realEstates;
        }

        public JustTweet Add(string title, string description, string address, string contact, int constructionYear, decimal? sellingPrice, decimal? rentingPrice, int type, string userId)
        {
            if (sellingPrice == null && rentingPrice == null)
            {
                throw new ArgumentException("Real estate be either for rent or sale, or both");
            }

            var newJustTweet = new JustTweet
            {
                Title = title,
                Description = description,
                Address = address,
                Contact = contact,
                ConstructionYear = constructionYear,
                JustTweetType = (JustTweetType)type,
                CreatedOn = DateTime.UtcNow,
                SellingPrice = sellingPrice,
                RentingPrice = rentingPrice,
                UserId = userId
            };

            if (rentingPrice != null)
            {
                newJustTweet.CanBeRented = true;
            }
            else
            {
                newJustTweet.CanBeRented = false;
            }

            if (sellingPrice != null)
            {
                newJustTweet.CanBeSold = true;
            }
            else
            {
                newJustTweet.CanBeSold = false;
            }

            this.realEstates.Add(newJustTweet);
            this.realEstates.SaveChanges();

            return newJustTweet;
        }

        public IQueryable<JustTweet> Get(int skip = 0, int take = 10)
        {
            return this.realEstates
                            .All()
                            .OrderByDescending(r => r.CreatedOn)
                            .Skip(skip)
                            .Take(take);
        }

        public JustTweet GetDetails(int id)
        {
            return this.realEstates.All().Where(re => re.Id == id).FirstOrDefault();
        }
    }
}
