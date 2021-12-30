using Microsoft.AspNetCore.Http;

namespace PokemonWebApplication.Models.RequestModel
{
    public class UpsertCardRequestModel
    {
        public int CardId { get; set; }
        public int CardSetNum { get; set; }
        public string CardName { get; set; }
        public int CardTypeNum { get; set; }
        public int CardNum { get; set; }
        public IFormFile CardImg { get; set; }
    }
}
