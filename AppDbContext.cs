using GestionEtudiant.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestionEtudiant
{
   

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Etudiant> Etudiants => Set<Etudiant>();
        public DbSet<Semestre> Semestres => Set<Semestre>();

        public DbSet<GestionEtudiant.Repository.Module> Modules => Set<GestionEtudiant.Repository.Module>();
        public DbSet<Filiere> Filieres => Set<Filiere>();
        public DbSet<Chapitre> Chapitres => Set<Chapitre>();
        public DbSet<Activite> Activites => Set<Activite>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Reponse> Reponses => Set<Reponse>();

        public void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Question>()
             .HasOne(q => q.Reponse)
             .WithOne(r => r.Question)
             .HasForeignKey<Reponse>(r => r.QuestionId);
            base.OnModelCreating(modelBuilder);

        }

    }
}
