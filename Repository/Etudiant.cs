using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;

        // Relation Many-to-Many avec Module
        [JsonIgnore]
        public List<Module> Modules { get; set; } = new List<Module>();
        [JsonIgnore]
        public List<Activite> Activites { get; set; } = new List<Activite>();
    }
}