﻿using Doctors.Domain.Entities;
using Doctors.Domain.Interfaces;

namespace Doctors.Infrastructure.Repositories
{
    public class DataSheetRepository : BaseRepository<DataSheet>, IDataSheetRepository
    {
        public DataSheetRepository(DataContext context) : base(context)
        {
        }
    }
}
