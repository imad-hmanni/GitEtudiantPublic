using GestionEtudiant.Repository;
using GestionEtudiant.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionEtudiant.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IService _service;

        public QuestionsController(IService service)
        {
            _service = service;
        }
        // GET: api/<ActivitesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllQuestions());
        }

        // GET api/<ActivitesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var question = _service.GetQuestionById(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        // POST api/<ActivitesController>
        [HttpPost]
        public IActionResult Create(Question question)
        {
            _service.AddQuestion(question);
            return Ok(question);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Question question, int ActiviteId)
        {
            if (id != question.Id) return BadRequest();
            _service.EditQuestion(question, ActiviteId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Question = _service.GetQuestionById(id);
            if (Question == null) return NotFound();
            _service.DeleteQuestion(Question);
            return NoContent();
        }
    }
}
