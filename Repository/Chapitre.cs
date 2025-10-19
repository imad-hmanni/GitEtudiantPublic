using System.Text.Json.Serialization;

namespace GestionEtudiant.Repository
{
    public class Chapitre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        // Relation Many-to-One avec Module
        public string Contenu { get; set; } = null!;
        public int ModuleId { get; set; }
        [JsonIgnore]
        public Module? Module { get; set; }
        [JsonIgnore]
        public List<Activite> Activites { get; set; } = new List<Activite>();
    }
}
