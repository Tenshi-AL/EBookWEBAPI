using EBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBook.Persistence.Configuring
{
    public class LanguageConfiguring : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(new Language[]
            {
                new Language() { Id = Guid.NewGuid(), BookLanguage = "UA" },
                new Language() { Id = Guid.NewGuid(), BookLanguage = "RU" },
                new Language() { Id = Guid.NewGuid(), BookLanguage = "USA" },
            });
        }
    }
}