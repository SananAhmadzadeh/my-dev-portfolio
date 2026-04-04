using Core.Entities.DTOs;
using Core.Utilities.Result.Abstract;

namespace Business.Services.Abstract
{
    public interface IAppLogService
    {
        Task<IDataResult<List<GetAllAppLogsDto>>> GetAllAppLogsAsync();
    }
}
