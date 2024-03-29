﻿using GestionDesStages.Shared.Models;

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
        PostulerStage PostulerStage(PostulerStage postulerStage);


        PostulerStage PostuleStage(PostulerStage postulerStage);

        IEnumerable<PostulerStage> GetCandidatureStageByStageId(string StageId);

    }
}
