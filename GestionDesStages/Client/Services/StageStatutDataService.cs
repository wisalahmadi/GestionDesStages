using GestionDesStages.Client.Interfaces;
using GestionDesStages.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

namespace GestionDesStages.Client.Services
{
    public class StageStatutDataService: IStageStatutDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StageDataService> _logger;

        public StageStatutDataService(HttpClient httpClient, ILogger<StageDataService> logger)
        {
            _httpClient = httpClient;
            this._logger = logger;

        }
        public async Task<IEnumerable<StageStatut>> GetAllStageStatuts()
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<StageStatut>>
                (await _httpClient.GetStreamAsync($"api/stagestatut"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention de données {ex}");
            }
            return null;

        }
    }
}
