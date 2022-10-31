using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Interface
{
    public interface IEntrepriseRepository
    {
        Entreprise AddEntreprise(Entreprise entreprise);
        Entreprise GetEntrepriseById(string id);

        Entreprise UpdateEntreprise(Entreprise entreprise);
    }
}
