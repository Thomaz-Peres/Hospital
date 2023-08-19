using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;

namespace Doctors.Infrastructure.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DataContext context) : base(context)
        {
        }
    }
}
