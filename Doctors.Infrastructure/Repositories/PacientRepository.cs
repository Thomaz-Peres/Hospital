using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;

namespace Doctors.Infrastructure.Repositories
{
    public class PacientRepository : BaseRepository<Pacient>, IPacientRepository
    {
        public PacientRepository(DataContext context) : base(context)
        {
        }
    }
}
