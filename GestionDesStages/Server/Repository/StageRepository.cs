﻿using GestionDesStages.Server.Data;
using GestionDesStages.Server.Interface;
using GestionDesStages.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesStages.Server.Repository
{
    public class StageRepository : IStageRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public StageRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Stage AddStage(Stage stage)
        {
            var addedEntity = _appDbContext.Stage.Add(stage);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
        public IEnumerable<Stage> GetAllStages()
        {
            // Obtenir TOUS (n'importe quelle entreprise) les stages actifs
            return _appDbContext.Stage.Where(c => c.StageStatutId == 1).Include(c => c.StageStatut).OrderByDescending(t => t.DateCreation);
        }
        public IEnumerable<Stage> GetAllStagesById(string id)
        {
            // Obtenir seulement les stages d'une entreprise (actif ou non)
            return _appDbContext.Stage.Include(c => c.StageStatut).Where(c => c.Id == id).OrderByDescending(t => t.DateCreation);
        }
        public Stage GetStageByStageId(string StageId)
        {
            // Obtenir un stage précis d'une entreprise
            return _appDbContext.Stage.Include(c => c.StageStatut).FirstOrDefault(c => c.StageId == new Guid(StageId));
        }
        public void DeleteStage(Guid StageId)
        {
            var foundStage = _appDbContext.Stage.FirstOrDefault(e => e.StageId == StageId);
            if (foundStage == null) return;

            _appDbContext.Stage.Remove(foundStage);
            _appDbContext.SaveChanges();
        }
    }
}
