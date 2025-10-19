using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using System;

namespace GestionEtudiant
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IBaseRepository<Etudiant>? _etudiants;
        private IBaseRepository<Semestre>? _semestres;
        private IBaseRepository<Module>? _modules;
        private IBaseRepository<Filiere>? _filieres;
        private IBaseRepository<Chapitre>? _chapitres;
        private IBaseRepository<Activite>? _activites;
        private IBaseRepository<Question>? _questions;
        private IBaseRepository<Reponse>? _reponses;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Etudiant> Etudiants => _etudiants ??= new BaseRepository<Etudiant>(_context);
        public IBaseRepository<Semestre> Semestres => _semestres ??= new BaseRepository<Semestre>(_context);

        public IBaseRepository<Module> Modules => _modules ??= new BaseRepository<Module>(_context);

        public IBaseRepository<Filiere> Filieres => _filieres ??=  new BaseRepository<Filiere>(_context);
        public IBaseRepository<Chapitre> Chapitres => _chapitres ??= new BaseRepository<Chapitre>(_context);
        public IBaseRepository<Activite> Activites => _activites ??= new BaseRepository<Activite>(_context);
        public IBaseRepository<Question> Questions => _questions ??= new BaseRepository<Question>(_context);
        public IBaseRepository<Reponse> Reponses => _reponses ??= new BaseRepository<Reponse>(_context);
        public void Commit() => _context.SaveChanges();
    }
}
