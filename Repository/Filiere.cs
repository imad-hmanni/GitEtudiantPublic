using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Filiere
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        // Relation One-to-Many avec Semestre
        [JsonIgnore]
        public List<GestionEtudiant.Repository.Module> Modules { get; set; } = new List<GestionEtudiant.Repository.Module>();
    }
}
