using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class GraduateReviewRepository : EFBaseRepository<GraduateReview, EducationDbContext>, IGraduateReviewRepository
    {
        private readonly EducationDbContext _context;
        public GraduateReviewRepository(EducationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<GraduateReview>> GetAllWithGraduateAsync()
        {
            return await _context.Set<GraduateReview>()
                                 .Include(r => r.Graduate)
                                 .ToListAsync();
        }

    }
}
