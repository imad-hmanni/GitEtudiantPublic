using GestionEtudiant;
using GestionEtudiant.DTO;
using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionEtudiant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemestresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Semestres
        [HttpGet]
        public IEnumerable<SemestreReadDto> GetSemestres()
        {
            List<SemestreReadDto> ListSemestreDto = new List<SemestreReadDto>();
            List<Semestre> semestres = _unitOfWork.Semestres.GetAll().ToList();
            foreach (var semestre in semestres)
            {
                SemestreReadDto semestreDto = new SemestreReadDto();
                semestreDto.Id = semestre.Id;
                semestreDto.Nom = semestre.Nom;
                List<GestionEtudiant.Repository.Module> m = _unitOfWork.Modules.Find(m => m.SemestreId == semestre.Id).ToList();
                foreach (var module in m)
                {
                    semestreDto.Modules.Add(module.Nom);
                }
                ListSemestreDto.Add(semestreDto);
            }
            return ListSemestreDto;
        }

        // GET: api/Semestres/5
        [HttpGet("{id}")]
        public IActionResult GetSemestre(int id)
        {
            var semestre = _unitOfWork.Semestres.GetById(id);

            if (semestre == null)
            {
                return NotFound();
            }

            return Ok(semestre);
        }

        // PUT: api/Semestres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSemestre(int id, Semestre semestre)
        {
            if (id != semestre.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Semestres.Update(semestre);

            try
            {
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemestreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Semestres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Semestre> PostSemestre(Semestre semestre)
        {
            _unitOfWork.Semestres.Add(semestre);
            _unitOfWork.Commit();

            return CreatedAtAction("GetSemestre", new { id = semestre.Id }, semestre);
        }

        // DELETE: api/Semestres/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSemestre(int id)
        {
            var semestre = _unitOfWork.Semestres.GetById(id);
            if (semestre == null)
            {
                return NotFound();
            }

            _unitOfWork.Semestres.Delete(semestre);
            _unitOfWork.Commit();

            return NoContent();
        }

        private bool SemestreExists(int id)
        {
            return _unitOfWork.Semestres.Any(e => e.Id == id);
        }
    }
}
