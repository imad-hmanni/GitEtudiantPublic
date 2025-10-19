using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using GestionEtudiant.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiant.Controllers
{
    [ApiController]
    [Route("api/filiere")]
    public class FilieresController : ControllerBase
    {
        private readonly IService _service;

        public FilieresController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllFilieres());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var filiere = _service.GetFiliereById(id);
            if (filiere == null) return NotFound();
            return Ok(filiere);
        }

        [HttpPost]
        public IActionResult Create(Filiere filiere)
        {
            _service.AddFiliere(filiere);
            return Ok(filiere);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Filiere filiere)
        {
            if (id != filiere.Id) return BadRequest();
            _service.EditFiliere(filiere);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filiere = _service.GetFiliereById(id);
            if (filiere == null) return NotFound();
            _service.DeleteFiliere(filiere);
            return NoContent();
        }
    }
}
