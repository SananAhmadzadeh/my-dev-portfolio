using Core.Utilities.Result.Abstract;
using Entities.DTOs.BlogDTOs;

namespace Business.Services.Abstract;

public interface IBlogService
{
    //public Task<IDataResult<List<GetAllBlogDTO>>> GetAllBlogsAsync(string languageCode);
    public Task<IDataResult<List<GetAllBlogDTO>>> GetAllBlogsAsync();
        
    public Task<IDataResult<GetBlogDTO>> GetBlogByIdAsync(Guid id);
        
    public Task<IResult> AddBlogAsync(CreateBlogDTO createBlogDTO);

    public Task<IResult> DeleteBlogAsync(Guid id);
        
    public Task<IResult> UpdateBlogAsync(Guid id, UpdateBlogDTO updateBlogDTO);
}
