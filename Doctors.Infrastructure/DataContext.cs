using Doctors.Domain.Entities;
using Doctors.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<DataSheet> DataSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Hospital;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                DoctorId = 1,
                Name = "Doctor Teste",
                Cpf = "79769206008",
                Crm = "12345",
                Specialty = "Pediatra",
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
