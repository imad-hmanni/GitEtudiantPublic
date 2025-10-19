using GestionEtudiant.Repository;

namespace GestionEtudiant.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Etudiant> Etudiants { get; }
        IBaseRepository<Semestre> Semestres { get; }
        IBaseRepository<Module> Modules { get; }
        IBaseRepository<Filiere> Filieres { get; }

        IBaseRepository<Chapitre> Chapitres { get; }
        IBaseRepository<Activite> Activites { get; }
        IBaseRepository<Question> Questions { get; }
        IBaseRepository<Reponse> Reponses { get; }

        void Commit();
    }
}
