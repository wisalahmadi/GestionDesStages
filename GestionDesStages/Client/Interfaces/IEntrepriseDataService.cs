using GestionDesStages.Shared.Models;

namespace GestionDesStages.Client.Interfaces
{
    public interface IEntrepriseDataService
    {
        Task<Entreprise> AddEntreprise(Entreprise entreprise);
        Task<IEnumerable<Entreprise>> GetAllEntreprises(string id = null);
        Task DeleteEntreprise(Guid StageId);
        Task UpdateEntreprise(Entreprise entreprise);
        Task<Entreprise> GetEntrepriseById(string Id);
    }
}
