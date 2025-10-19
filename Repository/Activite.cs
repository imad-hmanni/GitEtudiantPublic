using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Activite
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public DateTime Date { get; set; }
        [JsonIgnore]
        public List<Question> Questions { get; set; } = new List<Question>();
        // Relation Many-to-One avec Chapitre
        public int ChapitreId { get; set; }
        [JsonIgnore]
        public Chapitre? Chapitre { get; set; }
        public int EdudiantId { get; set; }
        [JsonIgnore]
        public Etudiant? Etudiant { get; set; }
    }
}
