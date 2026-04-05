using Core.Entities.Abstract;

namespace Entities.DTOs.BlogDTOs;

public class UpdateBlogDTO : IDto
{
    public Guid TeacherId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
