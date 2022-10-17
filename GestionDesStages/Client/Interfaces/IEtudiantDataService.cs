using GestionDesStages.Shared.Models;

namespace GestionDesStages.Client.Interfaces
{
    public interface IEtudiantDataService
    {
        Task<Etudiant> AddEtudiant(Etudiant etudiant);

        Task<Etudiant> GetEtudiantById(string v);

        Task UpdateEtudiant(Etudiant etudiant);
    }
}
