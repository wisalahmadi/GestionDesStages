using GestionDesStages.Shared.Models;

namespace GestionDesStages.Client.Interfaces
{
    public interface IStageDataService
    {
        Task<Stage> AddStage(Stage stage);

    }
}
