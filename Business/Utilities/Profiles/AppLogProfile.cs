using AutoMapper;
using Core.Entities.DTOs;
using Core.Logging;

namespace Business.Utilities.Profiles
{
    public class AppLogProfile : Profile
    {
        public AppLogProfile()
        {
            CreateMap<AppLog, GetAllAppLogsDto>();
        }
    }
}
