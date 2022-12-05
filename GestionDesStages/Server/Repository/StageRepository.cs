using GestionDesStages.Server.Data;
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


        public Stage UpdateStage(Stage stage)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundStage = _appDbContext.Stage.FirstOrDefault(e => e.StageId == stage.StageId);
            if (foundStage != null)
            {
                foundStage.Titre = stage.Titre;
                foundStage.Description = stage.Description;
                foundStage.StageStatutId = stage.StageStatutId;
                foundStage.DateCreation = stage.DateCreation;
                foundStage.Salaire = stage.Salaire;
                foundStage.TypeTravail = stage.TypeTravail;
                foundStage.Id = stage.Id;
                _appDbContext.SaveChanges();
            }
            return stage;
        }
        public IEnumerable<PostulerStage> GetCandidaturesStageByStageId(string StageId)
{
    // Obtenir les enregistrements des candidatures en ordre croissant de date de soumssion
    return _appDbContext.PostulerStage.Include(c => c.Etudiant).Where(c => c.StageId == new Guid(StageId)).OrderBy(d => d.DatePostule);
}
    }
}
