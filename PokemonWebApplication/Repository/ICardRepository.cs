using PokemonWebApplication.Models;
using PokemonWebApplication.Models.DataTransferObject;
using PokemonWebApplication.Models.RequestModel;
using PokemonWebApplication.Models.ResponseModel;
using System.Collections.Generic;

namespace PokemonWebApplication.Repository
{
    public interface ICardRepository
    {
        IEnumerable<CardInfoResponseModel> GetCard();
        CardInfoResponseModel GetCardById(int id);
        //int AddCard(CardInfo card);
        //int UpdateCard(CardInfo card);
        int DeleteCard(int id);
        int UpsertCardInfo(CardInfo card);
    }
}
