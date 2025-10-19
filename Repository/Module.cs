using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Module
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;

        // Relation Many-to-One avec Semestre
        public int SemestreId { get; set; }

        [JsonIgnore]
        public Semestre? Semestre { get; set; }

        // Relation Many-to-Many avec Etudiant
       
        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        // Relation Many-to-One avec Professeur
        public int? FiliereId { get; set; }
        [JsonIgnore]
        public Filiere? Filieres { get; set; }
        [JsonIgnore]
        public List<Chapitre> Chapitres { get; set; } = new List<Chapitre>();
    }
}