using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class HomeSection:BaseEntity, IEntity
    {
        public string Header { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
