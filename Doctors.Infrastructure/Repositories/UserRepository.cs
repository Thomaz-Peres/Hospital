using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;

namespace Doctors.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
