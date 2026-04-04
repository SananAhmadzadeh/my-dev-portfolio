using Core.Entities.Abstract;
using Entities.Common;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Lesson : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}
