using GestionDesStages.Client.Interfaces;
using GestionDesStages.Shared.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using GestionDesStages.Client.Services;

namespace GestionDesStages.Client.Services
{
    public class StageDataService: IStageDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StageDataService> _logger;

        public StageDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public StageDataService(HttpClient httpClient, ILogger<StageDataService> logger)
        {
            _httpClient = httpClient;
            this._logger = logger;
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
        public async Task<IEnumerable<Stage>> GetAllStages(string id = null)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Stage>>
                        (await _httpClient.GetStreamAsync("api/stage"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Stage>>
                        (await _httpClient.GetStreamAsync($"api/stage/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention de données {ex}");
            }
            return null;
        }
    }
}
