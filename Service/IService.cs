using GestionEtudiant.Repository;

namespace GestionEtudiant.Service
{
    public interface IService
    {
        /* Filiére */
        public Filiere AddFiliere(Filiere f);
        public void DeleteFiliere(Filiere f);
        public void EditFiliere(Filiere f);
        
        public Filiere? GetFiliereById(int id);
        public IEnumerable<Filiere> GetAllFilieres();

        /* Chapitre */
        public Chapitre AddChapitre(Chapitre c);
        public void DeleteChapitre(Chapitre chapitre);
        public void EditChapitre(Chapitre c, int moduleId);
        public Chapitre? GetChapitreById(int id);
        public IEnumerable<Chapitre> GetAllChapitres();

        /* Activité */
        public Activite AddActivite(Activite a);
        public void DeleteActivite(Activite activite);
        public void EditActivite(Activite a, int chapitreId);
        public Activite? GetActiviteById(int id);
        public IEnumerable<Activite> GetAllActivites();

        /* Question */
        public Question AddQuestion(Question q);
        public void DeleteQuestion(Question question);
        public void EditQuestion(Question q, int activiteId);
        public Question? GetQuestionById(int id);
        public IEnumerable<Question> GetAllQuestions();

        /* Reponse */
        public Reponse AddReponse(Reponse r);
        public void DeleteReponse(Reponse reponse);
        public void EditReponse(Reponse r, int questionId);
        public Reponse? GetReponseById(int id);
        public IEnumerable<Reponse> GetAllReponses();

        
    }
}
