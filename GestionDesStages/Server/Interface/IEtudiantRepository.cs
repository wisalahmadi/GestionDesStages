using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Interface
{
    public interface IEtudiantRepository
    {
        Etudiant AddEtudiant(Etudiant etudiant);

        Etudiant GetEtudiantById(string id);

        Etudiant UpdateEtudiant(Etudiant etudiant);
    }
}
