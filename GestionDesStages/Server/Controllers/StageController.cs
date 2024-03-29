﻿using GestionDesStages.Server.Interface;
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
        [HttpGet("GetStageByStageId/{StageId}")]
        public IActionResult GetStageByStageId(string StageId)
        {
            return Ok(_stageRepository.GetStageByStageId(StageId));
        }

        [HttpDelete("{StageId}")]

        public IActionResult DeleteStage(Guid StageId)
        {
            if (StageId == Guid.Empty)
                return BadRequest();

            var stageToDelete = (_stageRepository.GetStageByStageId(StageId.ToString()));
            if (stageToDelete == null)
                return NotFound();

            _stageRepository.DeleteStage(StageId);

            return NoContent();//success
        }
        [HttpPut]
        public IActionResult UpdateStage([FromBody] Stage stage)
        {
            if (stage == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // S'assurer que le stage existe dans la table avant de faire la mise à jour
            var stageToUpdate = _stageRepository.GetStageByStageId(stage.StageId.ToString());

            if (stageToUpdate == null)
                return NotFound();

            _stageRepository.UpdateStage(stage);

            return NoContent(); //success
        }
        [HttpPost("PostulerStage")]
        public IActionResult PostulerStage([FromBody] PostulerStage postulerStage)
        {
            if (postulerStage == null)
                return BadRequest();

            // Utiliser la date/heure du serveur pour situer la soumission de la candidature dans le temps
            postulerStage.DatePostule = System.DateTime.Now;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _stageRepository.PostulerStage(postulerStage);

            if (created != null)
            {
                return Created("postulerStage", created);
            }
            // Le candidat semble avoir déjà postulé
            return BadRequest();
        }
        [HttpGet("GetCandidaturesStageByStageId/{StageId}")]
        //[HttpGet("{StageId}")]
        public IActionResult GetCandidaturesStageByStageId(string StageId)
        {
            return Ok(_stageRepository.GetCandidaturesStageByStageId(StageId));
        }

    }
}
