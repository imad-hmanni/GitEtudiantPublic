using GestionEtudiant.DTO;
using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GestionEtudiant.Controllers
{
    [ApiController]
    [Route("api/module")]
    public class ModulesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModulesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // je veux faire un DTO
            
            var module = _unitOfWork.Modules.GetAll().ToList() ;
            List<ModuleReadDto> ldto = new List<ModuleReadDto>();
            foreach (var element in module)
            {
                ModuleReadDto dto = new ModuleReadDto();
                dto.Id = element.Id;
                dto.Nom = element.Nom;
                var semestre = _unitOfWork.Semestres.GetById(element.SemestreId);
                dto.SemestreNom = semestre.Nom;
                ldto.Add(dto);
            }
            return Ok(ldto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var module = _unitOfWork.Modules.GetById(id);
            if (module == null) return NotFound();
            ModuleReadDto dto = new ModuleReadDto();
            dto.Nom = module.Nom;
            var semestre = _unitOfWork.Semestres.GetById(module.SemestreId);
            dto.SemestreNom = semestre.Nom;
            return Ok(dto);
        }
        [HttpGet("/search")]
        public IActionResult GetByName(String name)
        {
            var modules = _unitOfWork.Modules.Find(m=>m.Nom.ToLower().Contains(name)).ToList();
            List<ModuleReadDto> ldto = new List<ModuleReadDto>();
            foreach (var module in modules)
            {
                ModuleReadDto dto = new ModuleReadDto();
                dto.Nom = module.Nom;
                var semestre = _unitOfWork.Semestres.GetById(module.SemestreId);
                dto.SemestreNom = semestre.Nom;
                ldto.Add(dto);
            }
            
            return Ok(ldto);
        }
        [HttpPost]
        public IActionResult Create(ModuleCreateDto dto)
        {
            var m = new GestionEtudiant.Repository.Module() ;
            m.Nom = dto.Nom;
            m.SemestreId = dto.SemestreId;
            _unitOfWork.Modules.Add(m);
            _unitOfWork.Commit();
            return Ok(m);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ModuleUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var m = new GestionEtudiant.Repository.Module();
            m.Id = dto.Id;
            m.Nom = dto.Nom;
            m.SemestreId = dto.SemestreId;
            _unitOfWork.Modules.Update(m);
            _unitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var module = _unitOfWork.Modules.GetById(id);
            if (module == null) return NotFound();
            _unitOfWork.Modules.Delete(module);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
