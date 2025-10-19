using GestionEtudiant.Repository;
using GestionEtudiant.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEtudiant.Controllers
{
    [Route("api/activite")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        private readonly IService _service;

        public ActivitesController(IService service)
        {
            _service = service;
        }
        // GET: api/<ActivitesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllActivites());
        }

        // GET api/<ActivitesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activite = _service.GetActiviteById(id);
            if (activite == null) return NotFound();
            return Ok(activite);
        }

        // POST api/<ActivitesController>
        [HttpPost]
        public IActionResult Create(Activite activite)
        {
            _service.AddActivite(activite);
            return Ok(activite);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Activite activite, int ChapitreId)
        {
            if (id != activite.Id) return BadRequest();
            _service.EditActivite(activite, ChapitreId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activite = _service.GetActiviteById(id);
            if (activite == null) return NotFound();
            _service.DeleteActivite(activite);
            return NoContent();
        }
    }
}
