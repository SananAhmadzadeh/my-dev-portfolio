using Core.Entities.Abstract;
using Core.Entities.Concrete.Auth;
using Entities.Common;
using System.Text.Json.Serialization;


namespace Entities.Concrete
{
    public class Teacher :BaseEntity,IEntity
    {
        public string Desc { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public Guid CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
