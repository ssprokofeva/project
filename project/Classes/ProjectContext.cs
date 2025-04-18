using System.Data;
using System.Data.Common;
using System.Data.Entity;

namespace project
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=ProjectContext")
        {
            Database.SetInitializer<ProjectContext>(null);

            Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exhibition> Exhibitions { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ваши настройки отношений остаются без изменений
            modelBuilder.Entity<Exhibition>()
                .HasRequired(e => e.Category)
                .WithMany(c => c.Exhibitions)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Participant>()
                .HasRequired(p => p.Exhibition)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.ExhibitionId);
        }
    }
         
}
    





