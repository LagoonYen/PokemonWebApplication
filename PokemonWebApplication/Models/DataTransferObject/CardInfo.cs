namespace PokemonWebApplication.Models.DataTransferObject
{
    public class CardInfo
    {
        public int CardId { get; set; }
        public int CardSetNum { get; set; }
        public string CardName { get; set; }
        public int CardTypeNum { get; set; }
        public int CardNum { get; set; }
        public string CardImgSrc { get; set; }
    }
}
