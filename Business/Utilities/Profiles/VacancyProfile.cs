using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.VacancyDTOs;

namespace Business.Utilities.Profiles
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<CreateVacancyDto, Vacancy>();

            CreateMap<UpdateVacancyDto, Vacancy>();

            CreateMap<Vacancy, GetVacancyDto>()
                .ConstructUsing(v=> new GetVacancyDto(
                    v.Title,
                    v.Category,
                    v.Location,
                    v.WorkType,
                    v.EmploymentType,
                    v.SalaryMin,
                    v.SalaryMax,
                    v.Currency,
                    v.IsNew,
                    v.IsActive,
                    v.VacancySkills.Select(vs => vs.Skill.Name).ToList()
                    ));

            CreateMap<Vacancy, GetAllVacanciesDto>()
           .ConstructUsing(v=> new GetAllVacanciesDto(
                    v.Id,
                    v.Title,
                    v.Category,
                    v.Location,
                    v.WorkType,
                    v.EmploymentType,
                    v.SalaryMin,
                    v.SalaryMax,
                    v.Currency,
                    v.IsNew,
                    v.IsActive,
                    v.VacancySkills.Select(vs => vs.Skill.Name).ToList()
                    ));
        }
    }
}
