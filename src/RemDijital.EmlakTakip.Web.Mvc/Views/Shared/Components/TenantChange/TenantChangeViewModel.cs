using Abp.AutoMapper;
using RemDijital.EmlakTakip.Sessions.Dto;

namespace RemDijital.EmlakTakip.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
