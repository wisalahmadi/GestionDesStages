using GestionDesStages.Server.Interface;
using GestionDesStages.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStages.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController: ControllerBase
    {
        private readonly IStageRepository _stageRepository;
        private readonly IStageStatutRepository stageStatutRepository;



        public StageController(IStageRepository stageRepository, IStageStatutRepository stageStatutRepository)
        {
            this._stageRepository = stageRepository;
            this.stageStatutRepository = stageStatutRepository;
        }

        [HttpPost]
        public IActionResult CreateStage([FromBody] Stage stage)
        {
            if (stage == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = _stageRepository.AddStage(stage);

            return Created("stage", created);
        }
        [HttpGet]
        public IActionResult GetAllStage()
        {
            return Ok(_stageRepository.GetAllStages());
        }
        [HttpGet("{id}")]
        public IActionResult GetAllStage(string id)
        {
            return Ok(_stageRepository.GetAllStagesById(id));
        }
    }
}
