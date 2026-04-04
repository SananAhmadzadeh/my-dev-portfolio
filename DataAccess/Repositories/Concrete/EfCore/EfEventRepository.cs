using Core.DataAccess.Repositories.Concrete.EfCore;
using DataAccess.EFCore;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfEventRepository : EFBaseRepository<Event,EducationDbContext>,IEventRepository
    {
        public EfEventRepository(EducationDbContext context) : base(context)
        {
            
        }

    }
}
