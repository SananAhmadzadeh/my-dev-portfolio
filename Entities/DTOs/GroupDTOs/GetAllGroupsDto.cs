using Core.Entities.Abstract;

public class GetAllGroupsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string CourseName { get; set; }

    public string TeacherFullName { get; set; }
}
