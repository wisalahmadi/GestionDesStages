using GestionDesStages.Shared.Models;

namespace GestionDesStages.Client.Interfaces
{
    public interface IStageDataService
    {
        Task<Stage> AddStage(Stage stage);
        Task<IEnumerable<Stage>> GetAllStages(string id=null);
        Task DeleteStage(Guid StageId);

        Task<Stage> GetStageByStageId(string StageId);
        Task UpdateStage(Stage stage);

        Task<PostulerStage> PostulerStage(PostulerStage postulerStage);

        Task<IEnumerable<PostulerStage>> GetCandidaturesStageByStageId(string StageId);
    }
}
