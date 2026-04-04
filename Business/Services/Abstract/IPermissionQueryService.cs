using Core.Entities.Concrete.Auth;

namespace Business.Services.Abstract
{
    public interface IPermissionQueryService
    {
        Task<List<Permission>> GetAllAsync();
    }
}
