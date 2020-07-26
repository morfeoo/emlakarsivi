using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.EstateTypes.Dto
{
    public class PagedEstateTypeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
