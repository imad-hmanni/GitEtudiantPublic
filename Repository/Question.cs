namespace GestionEtudiant.Repository
{
    public class Question
    {
        public int Id { get; set; }
        public int ActiviteId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Activite? Activite { get; set; }
        public string? question { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Reponse Reponse { get; set; } = new Reponse();
}
}
