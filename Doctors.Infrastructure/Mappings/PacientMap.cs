using Doctors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctors.Infrastructure.Mappings
{
    public class PacientMap : IEntityTypeConfiguration<Pacient>
    {
        public void Configure(EntityTypeBuilder<Pacient> builder)
        {
            builder.HasIndex(x => x.Cpf).IsUnique();
        }
    }
}
