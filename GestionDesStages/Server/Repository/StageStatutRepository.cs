using GestionDesStages.Server.Data;
using GestionDesStages.Server.Interface;
using GestionDesStages.Shared.Models;

namespace GestionDesStages.Server.Repository
{
    public class StageStatutRepository : IStageStatutRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public StageStatutRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<StageStatut> GetAllStageStatuts()
        {
            return _appDbContext.StageStatut;
        }
    }
}
