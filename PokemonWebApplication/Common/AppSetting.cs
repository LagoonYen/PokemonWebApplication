using Microsoft.Extensions.Configuration;

namespace PokemonWebApplication.Common
{
    public class AppSetting : IAppSetting
    {
        private readonly IConfiguration _configuration;

        public AppSetting(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            return _configuration.GetValue<string>("ConnectionString");
        } 
    }
}
