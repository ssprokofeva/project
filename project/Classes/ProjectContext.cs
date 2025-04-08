using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=ProjectContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exhibition>()
                .HasRequired(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Participant>()
                .HasRequired(p => p.Exhibition)
                .WithMany(e => e.Participants)
                .HasForeignKey(p => p.ExhibitionId);
        }
    }
}
