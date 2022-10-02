using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Interface
{
    public interface IStageStatutRepository
    {
        IEnumerable<StageStatut> GetAllStageStatuts();
    }
}
