using System.Data.Entity;

namespace project
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
            
          Database.SetInitializer(new CreateDatabaseIfNotExists<ProjectContext>());
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exhibition>()
                .HasRequired(e => e.Category)          // Указывает на связь с категорией
                .WithMany(c => c.Exhibitions)          // Категория может содержать много выставок
                .HasForeignKey(e => e.CategoryId);     // Указывает на внешний ключ в Exhibition

            modelBuilder.Entity<Participant>()
                .HasRequired(p => p.Exhibition)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.ExhibitionId);   // Указывает на внешний ключ в Participant
        }

    }
}
