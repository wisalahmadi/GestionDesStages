using GestionDesStages.Client.Interfaces;
using GestionDesStages.Shared.Models;
using System.Text.Json;
using System.Text;

namespace GestionDesStages.Client.Services
{
    public class EntrepriseDataService : IEntrepriseDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EntrepriseDataService> _logger;

        public EntrepriseDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public EntrepriseDataService(HttpClient httpClient, ILogger<EntrepriseDataService> logger)
        {
            _httpClient = httpClient;
            this._logger = logger;
        }
        public async Task<Entreprise> AddEntreprise(Entreprise entreprise)
        {
            var donneesJson =
                new StringContent(JsonSerializer.Serialize(entreprise), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/entreprise", donneesJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Entreprise>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }
        public async Task<IEnumerable<Entreprise>> GetAllEntreprises(string id = null)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Entreprise>>
                        (await _httpClient.GetStreamAsync("api/entreprise"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<Entreprise>>
                        (await _httpClient.GetStreamAsync($"api/entreprise/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention de données {ex}");
            }
            return null;
        }
        public async Task DeleteEntreprise(Guid EntrepriseId)
        {
            await _httpClient.DeleteAsync($"api/entreprise/{EntrepriseId}");
        }
        public async Task UpdateEntreprise(Entreprise entreprise)
        {
            var info =
                new StringContent(JsonSerializer.Serialize(entreprise), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/entreprise", info);
        }
        public async Task<Entreprise> GetEntrepriseById(string Id)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<Entreprise>
                    (await _httpClient.GetStreamAsync($"api/entreprise/{Id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention de données d'un enregistrement {ex}");
            }
            return null;
        }
    }
}
