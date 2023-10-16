using EBook.Domain.Models;
using EBook.Persistence.Configuring;
using Microsoft.EntityFrameworkCore;

namespace EBook.Persistence
{
    public class EBookContext:DbContext
    {
        public EBookContext(DbContextOptions <EBookContext> options):base(options){}
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Language> Languages { get; set; } 
        public DbSet<Jenre> Jenres { get; set; }
        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageConfiguring());
            modelBuilder.ApplyConfiguration(new JenreConfiguration());
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}