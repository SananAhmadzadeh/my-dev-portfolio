using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
//using Entities.TranslationConcrete;
using Entities.TranslationDTOs.AboutTranslationDTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Business.Services.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAboutAsync(CreateAboutDTO createAboutDTO)
        {
            //var existingAbout = await _unitOfWork.AboutRepository.GetAsync(
            //    a => a.Year == createAboutDTO.Year,
            //    incudes: "Translations");

            //var errors = new List<string>();

            //foreach (var trans in createAboutDTO.Translations)
            //{
            //    var currentSlug = $"{trans.LanguageCode.ToLower()}/about";

            //    var slugExists = await _unitOfWork.AboutRepository.GetAsync(a =>
            //        a.Year == createAboutDTO.Year &&
            //        a.Translations.Any(t =>
            //            t.LanguageCode == trans.LanguageCode ||
            //            t.Slug == currentSlug
            //        ));

            //    if (slugExists != null)
            //    {
            //        errors.Add($"'{trans.LanguageCode}' dili və ya '{currentSlug}' ünvanı artıq bu il üçün mövcuddur.");
            //    }
            //}

            //if (errors.Any())
            //    return new ErrorResult(string.Join(" | ", errors));

            //if (existingAbout != null)
            //{
            //    var newTranslations = _mapper.Map<List<AboutTranslation>>(createAboutDTO.Translations);

            //    foreach (var nt in newTranslations)
            //    {
            //        nt.AboutId = existingAbout.Id;
            //        existingAbout.Translations.Add(nt);
            //    }

            //    _unitOfWork.AboutRepository.Update(existingAbout);
            //}
            //else
            //{
            //    var about = _mapper.Map<About>(createAboutDTO);
            //    await _unitOfWork.AboutRepository.AddAsync(about);
            //}

            //var result = await _unitOfWork.SaveAsync();

            //return result > 0
            //    ? new SuccessResult("Məlumatlar uğurla qeyd edildi")
            //    : new ErrorResult("Xəta baş verdi");

            var newAbout = _mapper.Map<About>(createAboutDTO);

            await _unitOfWork.AboutRepository.AddAsync(newAbout);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult > 0 ? new SuccessResult("Haqqımızda hissəsi əlavə edildi")
                : new ErrorResult("Haqqımızda hissəsi əlavə edilmədi");
        }

        public async Task<IResult> DeleteAboutAsync(Guid aboutId)
        {
            //var existsAbout = await _unitOfWork.AboutRepository.GetAsync(
            //    a => a.Id == aboutId,
            //    "Translations"
            //);

            //if (existsAbout == null)
            //    return new ErrorResult("Məlumat tapılmadı");

            //var translationsToDelete = existsAbout.Translations
            //    .Where(t => langCodes.Any(lc => lc.Equals(t.LanguageCode, StringComparison.OrdinalIgnoreCase)))
            //    .ToList();

            //if (!translationsToDelete.Any())
            //    return new ErrorResult("Göstərilən dillərdə tərcümə tapılmadı");

            //if (existsAbout.Translations.Count == translationsToDelete.Count)
            //{
            //    _unitOfWork.AboutRepository.Delete(existsAbout);
            //}
            //else
            //{
            //    foreach (var trans in translationsToDelete)
            //    {
            //        existsAbout.Translations.Remove(trans);
            //    }
            //    _unitOfWork.AboutRepository.Update(existsAbout);
            //}

            //var result = await _unitOfWork.SaveAsync();

            //return result > 0
            //    ? new SuccessResult($"{translationsToDelete.Count} ədəd tərcümə silindi")
            //    : new ErrorResult("Silinmə zamanı xəta baş verdi");

            var deleteAbout = await _unitOfWork.AboutRepository.GetAsync(a=> a.Id == aboutId);

            if (deleteAbout == null)
            {
                return new ErrorResult("Haqqımızda hissəsi tapılmadı");
            }

            _unitOfWork.AboutRepository.Delete(deleteAbout);

            var saveResult = await _unitOfWork.SaveAsync();

            return saveResult > 0 ? new SuccessResult("Haqqımızda hissəsi silindi")
                     : new ErrorResult("Haqqımızda hissəsi silindi"); 
        }



        public async Task<IDataResult<GetAboutDTO>> GetAboutByIdAsync(Guid id)
        {
            //var existsAbout = await _unitOfWork.AboutRepository.GetAsync(
            //    a => a.Id == id,
            //    "Translations"
            //);

            //if (existsAbout == null)
            //    return new ErrorDataResult<GetAboutDTO>(
            //        null!,
            //        "Haqqında hissəsində axtardığınız məlumat tapılmadı"
            //    );

            //var dto = _mapper.Map<GetAboutDTO>(existsAbout);
            //return new SuccessDataResult<GetAboutDTO>(dto, "Haqqında hissəsi tapıldı");
            var result = await _unitOfWork.AboutRepository.GetAsync(a => a.Id == id);
            if(result is null )
                return new ErrorDataResult<GetAboutDTO>(_mapper.Map<GetAboutDTO>(result), $"{id} - li haqqımızda hissəsi tapılmadı");
            else
                return new SuccessDataResult<GetAboutDTO>(_mapper.Map<GetAboutDTO>(result), $"{id} - li haqqımızda hissəsi tapıldı");
        }

        public async Task<IDataResult<List<GetAllAboutDTO>>> GetAllAboutsAsync()
        {
            //var abouts = await _unitOfWork.AboutRepository.GetAllAsync(
            //    null!,
            //    "Translations"
            //);

            //if (abouts == null || !abouts.Any())
            //    return new ErrorDataResult<List<GetAllAboutDTO>>(
            //        new List<GetAllAboutDTO>(),
            //        "Məlumatlar tapılmadı"
            //    );

            //var dtoList = abouts.Select(about =>
            //{
            //    var translation = about.GetTranslation(languageCode);

            //    dynamic? trans = translation;

            //    return new GetAllAboutDTO
            //    {
            //        Id = about.Id,
            //        Year = about.Year,
            //        Translations = translation != null ? new List<GetAboutTranslationDTO>
            //    {
            //    new GetAboutTranslationDTO
            //    {
            //        LanguageCode = translation.LanguageCode,
            //        Title = trans?.Title ?? "Tərcümə tapılmadı",
            //        Description = trans?.Description ?? "Tərcümə tapılmadı",
            //        Slug = translation.Slug
            //    }
            //} : new List<GetAboutTranslationDTO>() 
            //    };
            //}).ToList();

            //return new SuccessDataResult<List<GetAllAboutDTO>>(dtoList, "Məlumatlar gətirildi");
            var result = await _unitOfWork.AboutRepository.GetAllAsync();

            // 1. Şərt: Siyahı null-durmu və ya içində element varmı?
            if (result == null || !result.Any())
            {
                // Data yoxdursa, boş siyahı və ya xəta mesajı qaytarırıq. 
                // Mapping-ə ehtiyac yoxdur, çünki data yoxdur.
                return new ErrorDataResult<List<GetAllAboutDTO>>("List edilə bilmədi");
            }

            // 2. Data varsa, yalnız bu zaman mapping edirik.
            var mappedResult = _mapper.Map<List<GetAllAboutDTO>>(result);

            return new SuccessDataResult<List<GetAllAboutDTO>>(mappedResult, "List edildi");

        }


        public async Task<IResult> UpdateAboutAsync(Guid id, UpdateAboutDTO dto)
        {
            //var about = await _unitOfWork.AboutRepository.GetAsync(
            //    a => a.Id == id,
            //    "Translations"
            //);

            //if (about == null)
            //    return new ErrorResult("Haqqında hissəsi tapılmadı");

            //if (dto.Translations != null && dto.Translations.Any())
            //{
            //    foreach (var transDto in dto.Translations)
            //    {
            //        var existingTranslation = about.Translations
            //            .FirstOrDefault(t => t.LanguageCode.Equals(transDto.LanguageCode, StringComparison.OrdinalIgnoreCase));

            //        if (existingTranslation == null)
            //        {
            //            return new ErrorResult($"'{transDto.LanguageCode}' dili üçün tərcümə mövcud deyil.");
            //        }

            //        _mapper.Map(transDto, existingTranslation);

            //        existingTranslation.Slug = $"{existingTranslation.LanguageCode.ToLower()}/about";
            //    }
            //}

            //about.UpdatedAt = DateTime.UtcNow;
            //_unitOfWork.AboutRepository.Update(about);

            //var result = await _unitOfWork.SaveAsync();

            //return result > 0
            //    ? new SuccessResult("Haqqında hissəsi yeniləndi")
            //    : new ErrorResult("Dəyişiklik edilmədi");

            var update = await _unitOfWork.AboutRepository.GetAsync(a => a.Id == id);

            if(update is null )
                return new ErrorResult($"{id} - li haqqımızda hissəsi tapılmadı");

            _mapper.Map(dto, update);

            await _unitOfWork.AboutRepository.Update(update);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("Update edilə bilmədi");

            return new SuccessResult("Update edildi");
        }

    }
}