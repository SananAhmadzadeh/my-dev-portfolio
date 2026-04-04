using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.BlogDTOs;
//using Entities.TranslationConcrete;
//using Entities.TranslationDTOs.BlogTranslationDTOs;

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
        //var teacherExists = await _unitOfWork.TeacherRepository.GetAsync(t => t.Id == createBlogDTO.TeacherId);
        //if (teacherExists == null)
        //{
        //    return new ErrorResult("Göstərilən müəllim (TeacherId) sistemdə tapılmadı. Bloq qeyd edilə bilməz.");
        //}

        //var errors = new List<string>();

        //foreach (var trans in createBlogDTO.Translations)
        //{
        //    var currentSlug = $"{trans.LanguageCode.ToLower()}/blog";

        //    var slugExists = await _unitOfWork.BlogRepository.GetAsync(b =>
        //        b.Translations.Any(t => t.LanguageCode == trans.LanguageCode && t.Slug == currentSlug));

        //    if (slugExists != null)
        //    {
        //        errors.Add($"'{trans.LanguageCode}' dilində '{currentSlug}' linki ilə artıq bloq mövcuddur.");
        //    }
        //}

        //if (errors.Any())
        //    return new ErrorResult(string.Join(" | ", errors));

        //var blog = _mapper.Map<Blog>(createBlogDTO);

        //foreach (var trans in blog.Translations)
        //{
        //    trans.Slug = $"{trans.LanguageCode.ToLower()}/blog";
        //}

        //await _unitOfWork.BlogRepository.AddAsync(blog);
        //var result = await _unitOfWork.SaveAsync();

        //return result > 0
        //    ? new SuccessResult("Bloq uğurla əlavə edildi")
        //    : new ErrorResult("Xəta baş verdi");

        var teacherExists = await _unitOfWork.TeacherRepository.GetAsync(t => t.Id == createBlogDTO.TeacherId);

        if(teacherExists == null)
        {
            return new ErrorResult("Göstərilən müəllim (TeacherId) sistemdə tapılmadı. Blog qeyd edilə bilməz.");
        }

        var newBlog = _mapper.Map<Blog>(createBlogDTO);

        await _unitOfWork.BlogRepository.AddAsync(newBlog);

        var saveResult = await _unitOfWork.SaveAsync();

        return saveResult > 0 ? new SuccessResult("Blog əlavə edildi")
            : new ErrorResult("Blog əlavə edilmədi");
    }



    public async Task<IResult> DeleteBlogAsync(Guid id)
    {
        //var existsBlog = await _unitOfWork.BlogRepository.GetAsync(
        //    a => a.Id == id,
        //    "Translations"
        //);

        //if (existsBlog == null)
        //    return new ErrorResult(ExceptionMessages.BlogNotFound);

        //_unitOfWork.BlogRepository.Delete(existsBlog);

        //var result = await _unitOfWork.SaveAsync();

        //if (result == 0)
        //    return new ErrorResult("Blog silinmədi");

        //return new SuccessResult("Blog silindi");

        var existsBlog = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if(existsBlog == null)
            return new ErrorResult("Blog tapılmadı");

        _unitOfWork.BlogRepository.Delete(existsBlog);

        var saveResult = await _unitOfWork.SaveAsync();

        return saveResult > 0 ? new SuccessResult("Blog hissəsi silindi")
                 : new ErrorResult("Blog hissəsi silindi");
    }

    public async Task<IDataResult<GetBlogDTO>> GetBlogByIdAsync(Guid id)
    {
        //var existsBlog = await _unitOfWork.BlogRepository.GetAsync(
        //    a => a.Id == id,
        //    "Translations"
        // );

        //if (existsBlog is null)
        //    return new ErrorDataResult<GetBlogDTO>(
        //        null!,
        //        $"Axdardığınız blog tapılmadı"
        //    );

        //var dto = _mapper.Map<GetBlogDTO>(existsBlog);
        //return new SuccessDataResult<GetBlogDTO>(dto, $"axdardığınız blog tapıldı");

        var existsBlog = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if (existsBlog == null)
            return new ErrorDataResult<GetBlogDTO>(_mapper.Map<GetBlogDTO>(existsBlog),"Blog tapılmadı");
        else
            return new SuccessDataResult<GetBlogDTO>(_mapper.Map<GetBlogDTO>(existsBlog), "Blog tapıldı");
    }

    public async Task<IDataResult<List<GetAllBlogDTO>>> GetAllBlogsAsync()
    {
        //var blogs = await _unitOfWork.BlogRepository.GetAllAsync(
        //    null!,
        //    "Translations"
        //    );

        //if (blogs == null || !blogs.Any())
        //    return new ErrorDataResult<List<GetAllBlogDTO>>(
        //        new List<GetAllBlogDTO>(),
        //        "Məlumatlar tapılmadı"
        //    );

        //var dtoList = blogs.Select(blog =>
        //{
        //    var translation = blog.GetTranslation(languageCode);

        //    dynamic? trans = translation;

        //    return new GetAllBlogDTO
        //    {
        //        Id = blog.Id,
        //        Translations = translation != null ? new List<GetBlogTranslationDTO>
        //        {
        //            new GetBlogTranslationDTO
        //            {
        //                    LanguageCode = translation.LanguageCode,
        //                    Title = trans?.Title ?? "Tərcümə tapılmadı",
        //                    Description = trans?.Description ?? "Tərcümə tapılmadı",
        //                    Slug = translation.Slug
        //            }
        //        } : new List<GetBlogTranslationDTO>()
        //    };
        //}).ToList();


        //return new SuccessDataResult<List<GetAllBlogDTO>>(dtoList, "Məlumatlar gətirildi");
        var result = await _unitOfWork.BlogRepository.GetAllAsync();

        // 1. Şərt: Siyahı null-durmu və ya içində element varmı?
        if (result == null || !result.Any())
        {
            // Data yoxdursa, boş siyahı və ya xəta mesajı qaytarırıq. 
            // Mapping-ə ehtiyac yoxdur, çünki data yoxdur.
            return new ErrorDataResult<List<GetAllBlogDTO>>("List edilə bilmədi");
        }

        // 2. Data varsa, yalnız bu zaman mapping edirik.
        var mappedResult = _mapper.Map<List<GetAllBlogDTO>>(result);

        return new SuccessDataResult<List<GetAllBlogDTO>>(mappedResult, "List edildi");
    }

    public async Task<IResult> UpdateBlogAsync(Guid id, UpdateBlogDTO updateBlogDTO)
    {
        //var existsBlog = await _unitOfWork.BlogRepository.GetAsync(
        //    a => a.Id == id,
        //    "Translations"
        // );

        //if (existsBlog == null)
        //    return new ErrorResult("Blog tapılmadı");

        //if (updateBlogDTO.Translations != null)
        //{
        //    var langCodes = updateBlogDTO.Translations.Select(t => t.LanguageCode).ToList();

        //    foreach (var oldTrans in existsBlog.Translations.ToList())
        //    {
        //        if (!langCodes.Contains(oldTrans.LanguageCode))
        //        {
        //            existsBlog.Translations.Remove(oldTrans);
        //        }
        //    }

        //    foreach (var transDto in updateBlogDTO.Translations)
        //    {
        //        var translation = existsBlog.Translations
        //            .FirstOrDefault(t => t.LanguageCode == transDto.LanguageCode);

        //        if (translation == null)
        //        {
        //            var newTranslation = _mapper.Map<BlogTranslation>(transDto);
        //            newTranslation.CreatedAt = DateTime.UtcNow;
        //            existsBlog.Translations.Add(newTranslation);
        //        }
        //        else
        //        {
        //            _mapper.Map(transDto, translation);
        //            translation.UpdatedAt = DateTime.UtcNow;
        //        }
        //    }
        //}

        //existsBlog.UpdatedAt = DateTime.UtcNow;
        //_unitOfWork.BlogRepository.Update(existsBlog);

        //await _unitOfWork.SaveAsync();

        //return new SuccessResult("Blog hissəsi dəyişdirildi");

        var update = await _unitOfWork.BlogRepository.GetAsync(a => a.Id == id);

        if (update is null)
            return new ErrorResult($"{id} - li blog tapılmadı");

        _mapper.Map(updateBlogDTO, update);

        await _unitOfWork.BlogRepository.Update(update);

        var saveResult = await _unitOfWork.SaveAsync();

        if (saveResult == 0)
            return new ErrorResult("Blog update edilə bilmədi");

        return new SuccessResult("Blog update edildi");
    }
}