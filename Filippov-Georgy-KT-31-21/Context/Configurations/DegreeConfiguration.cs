using Filippov_Georgy_KT_31_21.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filippov_Georgy_KT_31_21.Context.Configurations {
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree> {
        public void Configure(EntityTypeBuilder<Degree> builder) {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Degree { Id = 1, Name = "Кандидат наук" },
                new Degree { Id = 2, Name = "Доктор наук" }
            );
        }
    }
}
