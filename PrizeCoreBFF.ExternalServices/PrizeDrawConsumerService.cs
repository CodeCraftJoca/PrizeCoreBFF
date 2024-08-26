using Newtonsoft.Json;
using PrizeCoreBFF.ExternalServices.InterfaceServices;
using PrizeCoreBFF.ExternalServices.Models;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace PrizeCoreBFF.ExternalServices
{
    public class PrizeDrawConsumerService : IPrizeDrawConsumerService
    {
        private readonly HttpClient _httpClient;
        public PrizeDrawConsumerService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<ExternalPrizeDrawDetailsResponseModel> GetPrizeDrawAsync(int prizeId)
        {
            var endpoint = "https://gist.githubusercontent.com/CodeCraftJoca/bd5854b83c06a13697f96cc0ebedb53a/raw/e75893329655d012514cc8edc02acead1b7a98c5/Draws.json";

            var response = await _httpClient.GetStringAsync(endpoint);
            
            var draws = JsonSerializer.Deserialize<ExternalPrizeDrawDetailsResponseModel>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });


            return draws;

        }

        public async Task<ExternalTermsAndConditionsModel> GetTermsAndConditionsAsync(int prizeId)
        {
            var endpoint = "https://gist.githubusercontent.com/CodeCraftJoca/81e70adfcc201c6366d4df28beb1fc9a/raw/7b6c64fa1c831a13738f484c251865e7ce957a7b/TermsPrizeDraw.json";

            var response = await _httpClient.GetStringAsync(endpoint);
            
            var terms = JsonSerializer.Deserialize<ExternalTermsAndConditionsModel>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            });

            return terms;
        }
    }
}
