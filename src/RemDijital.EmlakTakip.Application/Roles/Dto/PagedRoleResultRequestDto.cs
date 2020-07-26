using Abp.Application.Services.Dto;

namespace RemDijital.EmlakTakip.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

