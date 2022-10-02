using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Interface
{
    public interface IStageRepository
    {
        Stage AddStage(Stage stage);
    }
}
