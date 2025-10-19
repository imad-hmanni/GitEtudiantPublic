using GestionEtudiant.Interfaces;
using GestionEtudiant.Repository;
using System.Diagnostics;
using System.Reflection;

namespace GestionEtudiant.Service
{
    public class ServiceImpl : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Activite AddActivite(Activite a)
        {
            _unitOfWork.Activites.Add(a);
            _unitOfWork.Commit();
            return a;
        }

        public Chapitre AddChapitre(Chapitre c)
        {
            _unitOfWork.Chapitres.Add(c);
            _unitOfWork.Commit();
            return c;
        }

        public Filiere AddFiliere(Filiere f)
        {
            _unitOfWork.Filieres.Add(f);
            _unitOfWork.Commit();
            return f;
        }

        public Question AddQuestion(Question q)
        {
            _unitOfWork.Questions.Add(q);
            _unitOfWork.Commit();
            return q;
        }

        public Reponse AddReponse(Reponse r)
        {
            _unitOfWork.Reponses.Add(r);
            _unitOfWork.Commit();
            return r;
        }

        public void DeleteActivite(Activite activite)
        {
            _unitOfWork.Activites.Delete(activite);
            _unitOfWork.Commit();
        }

        public void DeleteChapitre(Chapitre chapitre)
        {
            _unitOfWork.Chapitres.Delete(chapitre);
            _unitOfWork.Commit();
        }

        public void DeleteFiliere(Filiere f)
        {
            _unitOfWork.Filieres.Delete(f);
            _unitOfWork.Commit();
        }


        public void DeleteQuestion(Question question)
        {
            _unitOfWork.Questions.Delete(question);
            _unitOfWork.Commit();
        }

        public void DeleteReponse(Reponse reponse)
        {
            _unitOfWork.Reponses.Delete(reponse);
            _unitOfWork.Commit();
        }

        public void EditActivite(Activite a, int chapitreId)
        {
            
            a.ChapitreId = chapitreId;
            _unitOfWork.Activites.Update(a);
            _unitOfWork.Commit();
        }

        public void EditChapitre(Chapitre c, int moduleId)
        {
            c.ModuleId = moduleId;
            _unitOfWork.Chapitres.Update(c);
            _unitOfWork.Commit();
        }

        public void EditFiliere(Filiere f)
        {
            _unitOfWork.Filieres.Update(f);
            _unitOfWork.Commit();
        }

        public void EditQuestion(Question q, int activiteId)
        {
            q.ActiviteId = activiteId;
            _unitOfWork.Questions.Update(q);
            _unitOfWork.Commit();
        }

        public void EditReponse(Reponse r, int questionId)
        {
            r.QuestionId = questionId;
            _unitOfWork.Reponses.Update(r);
            _unitOfWork.Commit();
        }

        public Activite? GetActiviteById(int id)
        {
            var activite = _unitOfWork.Activites.GetById(id);
            return activite;
        }

        public IEnumerable<Activite> GetAllActivites()
        {
            List<Activite> filieres = _unitOfWork.Activites.GetAll().ToList();
            return filieres;
        }

        public IEnumerable<Chapitre> GetAllChapitres()
        {
            List<Chapitre> chapitres = _unitOfWork.Chapitres.GetAll().ToList();
            return chapitres;
        }

        public IEnumerable<Filiere> GetAllFilieres()
        {
            List<Filiere> filieres = _unitOfWork.Filieres.GetAll().ToList();
            return filieres;

        }

        public IEnumerable<Question> GetAllQuestions()
        {
            List<Question> questions = _unitOfWork.Questions.GetAll().ToList();
            return questions;
        }

        public IEnumerable<Reponse> GetAllReponses()
        {
            List<Reponse> reponse = _unitOfWork.Reponses.GetAll().ToList();
            return reponse;
        }

        public Chapitre? GetChapitreById(int id)
        {
            var chapitre = _unitOfWork.Chapitres.GetById(id);
            return chapitre;
        }

        public Filiere? GetFiliereById(int id)
        {
            var filiere = _unitOfWork.Filieres.GetById(id);
            return filiere;
        }

        public Question? GetQuestionById(int id)
        {
            var question = _unitOfWork.Questions.GetById(id);
            return question;
        }

        public Reponse? GetReponseById(int id)
        {
            var reponse = _unitOfWork.Reponses.GetById(id);
            return reponse;
        }
    }
}
