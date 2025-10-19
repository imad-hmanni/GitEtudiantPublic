namespace GestionEtudiant.DTO
{
    public class SemestreReadDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public List<string> Modules { get; set; } = new List<string>();
    }
}
