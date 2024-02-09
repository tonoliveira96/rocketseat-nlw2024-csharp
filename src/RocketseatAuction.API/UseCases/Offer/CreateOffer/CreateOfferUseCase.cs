using RocketseatAuction.API.Comunication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offer.CreateOffer
{
    public class CreateOfferUseCase
    {   
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var user = _loggedUser.User();

            var offer = new Entities.Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };

            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
