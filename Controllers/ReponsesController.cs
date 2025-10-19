using Azure;
using GestionEtudiant.Repository;
using GestionEtudiant.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEtudiant.Controllers
{
    [Route("api/reponse")]
    [ApiController]
    public class ReponsesController : ControllerBase
    {
        private readonly IService _service;

        public ReponsesController(IService service)
        {
            _service = service;
        }
        // GET: api/<ActivitesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllReponses());
        }

        // GET api/<ActivitesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reponse = _service.GetReponseById(id);
            if (reponse == null) return NotFound();
            return Ok(reponse);
        }

        // POST api/<ActivitesController>
        [HttpPost]
        public IActionResult Create(Reponse reponse)
        {
            _service.AddReponse(reponse);
            return Ok(reponse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Reponse reponse, int ActiviteId)
        {
            if (id != reponse.Id) return BadRequest();
            _service.EditReponse(reponse, ActiviteId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reponse = _service.GetReponseById(id);
            if (reponse == null) return NotFound();
            _service.DeleteReponse(reponse);
            return NoContent();
        }
    }
}
