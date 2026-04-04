using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class GraduateReview : BaseEntity , IEntity
    {
        public Guid GraduateId { get; set; } 
        public string Comment { get; set; }   
        public double Rating { get; set; }    
        public Graduate Graduate { get; set; }
    }
}
