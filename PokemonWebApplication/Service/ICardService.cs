using PokemonWebApplication.Models.ResponseModel;
using PokemonWebApplication.Models.RequestModel;
using System.Collections.Generic;

namespace PokemonWebApplication.Service
{
    public interface ICardService
    {
        IEnumerable<CardSetInfoViewModel> GetCardSetName();
        IEnumerable<CardSetInfoViewModel> GetCardSetNameFromEnum();
        IEnumerable<CardTypeInfoViewModel> GetCardTypeNameFromEnum();
        IEnumerable<CardInfoViewModel> GetCardBySet(GetCardBySetRequestModel model);
        IEnumerable<CardInfoViewModel> GetCard();
        CardInfoResponseModel GetCardById(int id);
        //int AddCard(CardInfo card);
        //int UpdateCard(CardInfo card);
        int UpsertCardInfo(UpsertCardRequestModel card);
        int DeleteCard(int id);
    }
}
