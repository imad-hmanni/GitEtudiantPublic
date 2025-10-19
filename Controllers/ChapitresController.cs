using GestionEtudiant;
using GestionEtudiant.Repository;
using GestionEtudiant.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GestionEtudiant.DTO;

namespace GestionEtudiant.Controllers
{
    [Route("api/chapitre")]
    [ApiController]
    public class ChapitresController : ControllerBase
    {
        private readonly IService _service;

        public ChapitresController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllChapitres());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var chapitre = _service.GetChapitreById(id);
            if (chapitre == null) return NotFound();
            return Ok(chapitre);
        }

        [HttpGet("/prompt")]
        public async Task<IActionResult> Get(String prompt)
        {
            var llm = new llmAPI();
            var result = await llm.GenerateAsync(prompt);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChapitreCreateDto dto, String prompt)
        {
            /* ici c'est un commentaire */
            var llm = new llmAPI();
            String content = await llm.GenerateAsync(prompt);
            var chapitre = new Chapitre();
            chapitre.Titre = dto.titre;
            chapitre.Contenu = content;
            chapitre.ModuleId = dto.ModuleId;
            _service.AddChapitre(chapitre);
            return Ok(chapitre);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Chapitre chapitre, int ModuleId)
        {
            if (id != chapitre.Id) return BadRequest();
            _service.EditChapitre(chapitre,ModuleId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var chapitre = _service.GetChapitreById(id);
            if (chapitre == null) return NotFound();
            _service.DeleteChapitre(chapitre);
            return NoContent();
        }
    }
}
