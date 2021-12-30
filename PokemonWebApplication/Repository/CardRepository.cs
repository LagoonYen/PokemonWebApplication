using Dapper;
using PokemonWebApplication.Common;
using PokemonWebApplication.Models;
using PokemonWebApplication.Models.DataTransferObject;
using PokemonWebApplication.Models.RequestModel;
using PokemonWebApplication.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PokemonWebApplication.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly IAppSetting _appSettings;

        public CardRepository(IAppSetting appSettings)
        {
            _appSettings = appSettings;
        }


        public IEnumerable<CardInfoResponseModel> GetCard()
        {
            try
            {
                using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
                {
                    var sql = @"SELECT * FROM CardInfo";
                    return conn.Query<CardInfoResponseModel>(sql);
                }
            }
            catch
            {
                throw;
            }
        }

        public CardInfoResponseModel GetCardById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
                {
                    var sql = $@"SELECT * FROM CardInfo WHERE CardId = {id}";
                    return conn.QueryFirstOrDefault<CardInfoResponseModel>(sql);
                }
            }
            catch
            {
                throw;
            }
        }

        //public int AddCard(CardInfo card)
        //{
        //    try
        //    {
        //        using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
        //        {
        //            var sql = $@"INSERT INTO CardInfo (CardSetNum,CardName,CardTypeNum,CardNum) Values (@CardSetNum,@CardName,@CardType,@CardNum);";
        //            var para = new 
        //            {
        //                CardSetNum = card.CardSetNum,
        //                CardName = card.CardName,
        //                CardTypeNum = card.CardType,
        //                CardNum = card.CardNum
        //            };
        //            return conn.Execute(sql,para);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public int UpdateCard(CardInfo card)
        //{
        //    try
        //    {
        //        using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
        //        {
        //            var sql = $@"UPDATE CardInfo Set CardSetNum = @CardSetNum, CardName = @CardName, CardTypeNum = @CardType, CardNum = @CardNum WHERE CardId = @CardId;";
        //            var para = new
        //            {
        //                CardId = card.CardId,
        //                CardNum = card.CardNum,
        //                CardSetNum = card.CardSetNum,
        //                CardName = card.CardName,
        //                CardTypeNum = card.CardType
        //            };
        //            return conn.Execute(sql, para);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public int DeleteCard(int id)  //刪除
        {
            try
            {
                using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
                {
                    var sql = $@"DELETE CardInfo WHERE CardId = @CardId;";
                    var para = new
                    {
                        CardId = id
                    };
                    return conn.Execute(sql, para);
                }
            }
            catch
            {
                throw;
            }
        }

        public int UpsertCardInfo(CardInfo card)  //修改或新增卡片
        {
            try
            {
                using (var conn = new SqlConnection(_appSettings.GetConnectionString()))
                {
                    var sql = $@"BEGIN TRANSACTION
                                SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

                                UPDATE CardInfo WITH(ROWLOCK)
                                Set CardSetNum = @CardSetNum, CardName = @CardName, CardTypeNum = @CardTypeNum, CardNum = @CardNum, CardImgSrc = @CardImgSrc
                                WHERE [CardId] = @CardId;

                                IF @@rowcount=0
                                BEGIN
                                    INSERT INTO CardInfo
                                    (CardSetNum, CardName, CardTypeNum, CardNum, CardImgSrc) Values(@CardSetNum, @CardName, @CardTypeNum, @CardNum, @CardImgSrc)
                                END
                                COMMIT TRANSACTION";
                    var para = new
                    {
                        CardId = card.CardId,
                        CardNum = card.CardNum,
                        CardSetNum = card.CardSetNum,
                        CardName = card.CardName,
                        CardTypeNum = card.CardTypeNum,
                        CardImgSrc = card.CardImgSrc,
                    };
                    return conn.Execute(sql, para);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
