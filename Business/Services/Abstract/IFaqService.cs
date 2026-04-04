using Core.Utilities.Result.Abstract;
using Entities.DTOs.HomePageDTOs.FaqSection;


namespace Business.Services.Abstract
{
    public interface IFaqService
    {
        Task<IDataResult<FaqSectionDto>> GetFaqSectionAsync();
    }
}
