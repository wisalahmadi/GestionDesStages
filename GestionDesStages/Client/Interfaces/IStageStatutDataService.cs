using GestionDesStages.Shared.Models;

namespace GestionDesStages.Client.Interfaces
{
    public interface IStageStatutDataService
    {
        Task<IEnumerable<StageStatut>> GetAllStageStatuts();

    }
}
