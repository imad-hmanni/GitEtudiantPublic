namespace GestionEtudiant.Repository
{
    public class Reponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Question? Question { get; set; }
        public string? reponse { get; set; }
    }
}
