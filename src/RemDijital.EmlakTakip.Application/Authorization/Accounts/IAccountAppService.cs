using System.Threading.Tasks;
using Abp.Application.Services;
using RemDijital.EmlakTakip.Authorization.Accounts.Dto;

namespace RemDijital.EmlakTakip.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
