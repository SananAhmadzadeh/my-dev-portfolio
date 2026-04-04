using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;


namespace Entities.DTOs.GraduateDTOs
{
    public record CreateGraduateDto(
        string? FirstName,
        string? LastName,
        IFormFile? ProfileImageUrl,
        string? Position,
        string? Company) : IDto;
}
