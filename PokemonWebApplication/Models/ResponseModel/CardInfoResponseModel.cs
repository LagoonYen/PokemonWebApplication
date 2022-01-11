namespace PokemonWebApplication.Models.ResponseModel
{
    public class CardInfoResponseModel
    {
        public int CardId { get; set; }
        public int CardSetNum { get; set; }
        public string CardName { get; set; }
        public int CardTypeNum { get; set; }
        public int CardNum { get; set; }
        public string CardImgSrc { get; set; }
    }

    public class CardSetInfoViewModel //取卡組名稱
    {
        public int CardSetNum { get; set; }
        public string CardSetName { get; set; }
    }

    public class CardTypeInfoViewModel  //取卡片類別名稱
    {
        public int CardTypeNum { get; set; }
        public string CardTypeName { get; set; }
    }

    public class CardInfoViewModel //取所有資料
    {
        public int CardId { get; set; }
        public int CardSetNum { get; set; }
        public string CardSetName { get; set; }
        public string CardName { get; set; }
        public int CardTypeNum { get; set; }
        public string CardTypeName { get; set; }
        public int CardNum { get; set; }
        public string CardImgSrc { set; get; }
    }
}
