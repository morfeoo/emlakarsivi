using System.Threading.Tasks;
using Abp.Application.Services;
using RemDijital.EmlakTakip.Sessions.Dto;

namespace RemDijital.EmlakTakip.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
