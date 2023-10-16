using EBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBook.Persistence.Configuring
{
    public class JenreConfiguration : IEntityTypeConfiguration<Jenre>
    {
        public void Configure(EntityTypeBuilder<Jenre> builder)
        {
            builder.Property(p=>p.Title).HasMaxLength(50);

            builder.HasData(new Jenre[]
            {
                new Jenre () { Id = Guid.NewGuid(), Title = "Фэнтези" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Детективы" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Эротика" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Ужасы" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Приключения" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Поэзия" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Фантастика" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Любовные романы" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Книги для дошкольников" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Бизнес-литература" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Психология" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Искусство и культура" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Научная литература" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Изучение языков" },
                new Jenre () { Id = Guid.NewGuid(), Title = "Компьютерная литература" },
            });
        }
    }
}