using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Semestre
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;

        // Relation One-to-Many avec Module
        [JsonIgnore]
        public List<Module> Modules { get; set; } = new List<Module>();
    }
}