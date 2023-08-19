using Doctors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctors.Infrastructure.Mappings
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasIndex(x => x.Cpf).IsUnique();
            builder.HasIndex(x => x.Crm).IsUnique();
        }
    }
}
