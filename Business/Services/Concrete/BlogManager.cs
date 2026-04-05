using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.BlogDTOs;

namespace Business.Services.Concrete;

public class BlogManager : IBlogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlogManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult> AddBlogAsync(CreateBlogDTO createBlogDTO)
    {
        var teacherExists = await _unitOfWork.TeacherRepository.GetAsync(t => t.Id == createBlogDTO.TeacherId);

        if (teacherExists == null)
        {
            return new ErrorResult("Göstərilən müəllim sistemdə tapılmadı. Blog qeyd edilə bilməz.");
        }

        var newBlog = _mapper.Map<Blog>(createBlogDTO);

        await _unitOfWork.BlogRepository.AddAsync(newBlog);

        var saveResult = await _unitOfWork.SaveAsync();

        return saveResult > 0 ? new SuccessResult("Blog əlavə edildi")
            : new ErrorResult("Blog əlavə edilmədi");
    }

    public async Task<IResult> DeleteBlogAsync(Guid id)
    {
        var existsBlog = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if (existsBlog == null)
            return new ErrorResult("Blog tapılmadı");

        _unitOfWork.BlogRepository.Delete(existsBlog);

        var saveResult = await _unitOfWork.SaveAsync();

        return saveResult > 0 ? new SuccessResult("Blog hissəsi silindi")
                 : new ErrorResult("Blog hissəsi silindi");
    }

    public async Task<IDataResult<GetBlogDTO>> GetBlogByIdAsync(Guid id)
    {
        var existsBlog = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if (existsBlog == null)
            return new ErrorDataResult<GetBlogDTO>(_mapper.Map<GetBlogDTO>(existsBlog), "Blog tapılmadı");
        else
            return new SuccessDataResult<GetBlogDTO>(_mapper.Map<GetBlogDTO>(existsBlog), "Blog tapıldı");
    }

    public async Task<IDataResult<List<GetAllBlogDTO>>> GetAllBlogsAsync()
    {
        var result = await _unitOfWork.BlogRepository.GetAllAsync();

        if (result == null || !result.Any())
        {
            return new ErrorDataResult<List<GetAllBlogDTO>>("List edilə bilmədi");
        }

        var mappedResult = _mapper.Map<List<GetAllBlogDTO>>(result);

        return new SuccessDataResult<List<GetAllBlogDTO>>(mappedResult, "List edildi");
    }

    public async Task<IResult> UpdateBlogAsync(Guid id, UpdateBlogDTO updateBlogDTO)
    {
        var update = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if (update is null)
            return new ErrorResult($"{id} - li blog tapılmadı");

        var teacherExists = await _unitOfWork.TeacherRepository.GetAsync(t => t.Id == updateBlogDTO.TeacherId);
        if (teacherExists == null)
            return new ErrorResult("Göstərilən müəllim sistemdə tapılmadı. Blog update edilə bilməz.");

        _mapper.Map(updateBlogDTO, update);

        await _unitOfWork.BlogRepository.Update(update);

        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult == 0)
            return new ErrorResult("Blog update edilə bilmədi");

        return new SuccessResult("Blog update edildi");
    }
}