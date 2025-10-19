using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiant.Controllers
{
    [ApiController]
    [Route("api/etudiant")]
    public class EtudiantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EtudiantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_unitOfWork.Etudiants.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var etudiant = _unitOfWork.Etudiants.GetById(id);
            if (etudiant == null) return NotFound();
            return Ok(etudiant);
        }

        [HttpPost]
        public IActionResult Create(Etudiant etudiant)
        {
            _unitOfWork.Etudiants.Add(etudiant);
            _unitOfWork.Commit();
            return Ok(etudiant);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id) return BadRequest();
            _unitOfWork.Etudiants.Update(etudiant);
            _unitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var etudiant = _unitOfWork.Etudiants.GetById(id);
            if (etudiant == null) return NotFound();
            _unitOfWork.Etudiants.Delete(etudiant);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
