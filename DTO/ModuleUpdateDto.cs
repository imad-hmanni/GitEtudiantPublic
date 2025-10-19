namespace GestionEtudiant.DTO
{
    public class ModuleUpdateDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public int SemestreId { get; set; } 
    }
}
