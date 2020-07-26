using Abp.Application.Services;
using RemDijital.EmlakTakip.MultiTenancy.Dto;

namespace RemDijital.EmlakTakip.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

