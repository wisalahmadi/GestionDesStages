using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Interface
{
    public interface IStageRepository
    {
        Stage AddStage(Stage stage);
        IEnumerable<Stage> GetAllStages();
        IEnumerable<Stage> GetAllStagesById(string id);
        Stage GetStageByStageId(string StageId);
        void DeleteStage(Guid StageId);

        Stage UpdateStage(Stage stage);


    }
}
