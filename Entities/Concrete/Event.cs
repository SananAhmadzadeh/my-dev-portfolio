using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{

    public class Event: BaseEntity, IEntity
    {
        public bool IsFree { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}
