using GestionDesStages.Client.Interfaces;
using GestionDesStages.Shared.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace GestionDesStages.Client.Services
{
    public class StageDataService: IStageDataService
    {
        private readonly HttpClient _httpClient;

        public StageDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Stage> AddStage(Stage stage)
        {
            var donneesJson =
                new StringContent(JsonSerializer.Serialize(stage), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/stage", donneesJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Stage>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }
    }
}
