using Microsoft.AspNetCore.Mvc;
using PokemonWebApplication.Models.DataTransferObject;
using PokemonWebApplication.Models.RequestModel;
using PokemonWebApplication.Models.ResponseModel;
using PokemonWebApplication.Service;
using System.Collections.Generic;

namespace PokemonWebApplication.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("[action]")]
        public IEnumerable<CardSetInfoViewModel> GetCardSetName()  //取得系列名稱
        {
            return _cardService.GetCardSetName();
        }

        [HttpGet("[action]")]
        public IEnumerable<CardSetInfoViewModel> GetCardSetNameFromEnum()  //取得全部系列名稱
        {
            return _cardService.GetCardSetNameFromEnum();
        }

        [HttpGet("[action]")]
        public IEnumerable<CardTypeInfoViewModel> GetCardTypeNameFromEnum()  //取得全部屬性名稱
        {
            return _cardService.GetCardTypeNameFromEnum();
        }

        [HttpPost("GetCardBySet")]
        public IEnumerable<CardInfoViewModel> GetCardBySet([FromBody] GetCardBySetRequestModel model)  //取得系列名稱下的卡片資訊
        {
            return _cardService.GetCardBySet(model);
        }

        [HttpGet("GetAllCardList")]
        public IEnumerable<CardInfoViewModel> GetAllCardList()  //取得全體卡片資料
        {
            return _cardService.GetCard();
        }

        [HttpGet("Get/{id}")]
        public CardInfoResponseModel GetCardById(int id)  //取得卡片資料(id)
        {
            return _cardService.GetCardById(id);
        }

        [HttpPatch("[action]")]
        public int UpsertCardInfo([FromForm] UpsertCardRequestModel card)  //新增或修改卡片
        {
            
            return _cardService.UpsertCardInfo(card);
        }

        //[HttpPost("Add")]  //新增卡片資料
        //public int AddCard([FromForm] CardInfo card)
        //{
        //    return _cardService.AddCard(card);
        //}

        //[HttpPatch("Update")]  //修改卡片資料
        //public int UpdateCard([FromForm] CardInfo card)
        //{
        //    return _cardService.UpdateCard(card);
        //}

        [HttpDelete("Delete/{id}")]  //刪除卡片
        public int DeleteCard(int id)
        {
            return _cardService.DeleteCard(id);
        }
    }
}
