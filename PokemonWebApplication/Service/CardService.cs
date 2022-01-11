using Microsoft.AspNetCore.Mvc;
using PokemonWebApplication.Enums;
using PokemonWebApplication.Extensions;
using PokemonWebApplication.Models.DataTransferObject;
using PokemonWebApplication.Models.RequestModel;
using PokemonWebApplication.Models.ResponseModel;
using PokemonWebApplication.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PokemonWebApplication.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public IEnumerable<CardSetInfoViewModel> GetCardSetName()
        {
            var cardInfo = _cardRepository.GetCard();

            return cardInfo
                .Select(x => x.CardSetNum).Distinct()
                .Select(x => new CardSetInfoViewModel
            {
                CardSetNum = x,
                CardSetName = x.GetDescription(typeof(CardSetNumEnum)),
            });
        }

        public IEnumerable<CardSetInfoViewModel> GetCardSetNameFromEnum()
        {
            return Enum.GetValues<CardSetNumEnum>().Select(x => new CardSetInfoViewModel
            {
                CardSetNum = (int)x,
                CardSetName = x.GetDescription(),
            });
        }

        public IEnumerable<CardTypeInfoViewModel> GetCardTypeNameFromEnum()
        {
            return Enum.GetValues<CardTypeEnum>().Select(x => new CardTypeInfoViewModel
                {
                    CardTypeNum = (int)x,
                    CardTypeName = x.GetDescription(),
                });
        }

        public IEnumerable<CardInfoViewModel> GetCardBySet(GetCardBySetRequestModel model)
        {
            var cardInfo = _cardRepository.GetCard();

            return cardInfo
                .Where(x => x.CardSetNum == model.SetId)
                .OrderBy(x => x.CardNum)
                .Select(x => new CardInfoViewModel
                {
                    CardId = x.CardId,
                    CardSetNum = x.CardSetNum,
                    CardSetName = x.CardSetNum.GetDescription(typeof(CardSetNumEnum)),
                    CardNum = x.CardNum,
                    CardName = x.CardName,
                    CardTypeNum = x.CardTypeNum,
                    CardTypeName = x.CardTypeNum.GetDescription(typeof(CardTypeEnum)),
                    CardImgSrc = x.CardImgSrc
                });
        }

        public IEnumerable<CardInfoViewModel> GetCard()
        {
            var cardInfo = _cardRepository.GetCard();

            return cardInfo
                .OrderBy(e => e.CardSetNum)
                .ThenBy(a => a.CardNum)
                .Select(c => new CardInfoViewModel
            {
                CardId = c.CardId,
                CardSetName = c.CardSetNum.GetDescription(typeof(CardSetNumEnum)),
                CardNum = c.CardNum,
                CardName = c.CardName,
                CardTypeName = c.CardTypeNum.GetDescription(typeof(CardTypeEnum)),
                CardImgSrc = c.CardImgSrc
                //CardType = ((CardTypeEnum)c.CardType).GetDescription()
            });
        }

        public CardInfoResponseModel GetCardById(int id)
        {
            return _cardRepository.GetCardById(id);
        }

        //public int AddCard(CardInfo card)  //新增卡片
        //{
        //    return _cardRepository.AddCard(card);
        //}

        //public int UpdateCard(CardInfo card)  //修改卡片
        //{
        //    return _cardRepository.UpdateCard(card);
        //}

        public int DeleteCard(int id)  //刪除卡片
        {
            return _cardRepository.DeleteCard(id);
        }

        public int UpsertCardInfo(UpsertCardRequestModel card)
        {
            var cardInfo = _cardRepository.GetCardById(card.CardId);
            var imgSrc = cardInfo.CardImgSrc;
            
            if (string.Empty is var fileName && card.CardImg != null)
            {
                var fileExtension = card.CardImg.FileName.Split(".").TakeLast(1).FirstOrDefault();
                fileName = !string.IsNullOrWhiteSpace(imgSrc) ? imgSrc : $"./wwwroot/resource/CardImg/{Guid.NewGuid().ToString()}.{fileExtension}";
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    card.CardImg.CopyTo(stream);
                }
            }
            return _cardRepository.UpsertCardInfo(new CardInfo
            {
                CardId = card.CardId,
                CardSetNum = card.CardSetNum,
                CardNum = card.CardNum,
                CardName = card.CardName,
                CardTypeNum = card.CardTypeNum,
                CardImgSrc = fileName
            });
        }
    }
}
