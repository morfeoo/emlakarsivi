using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Et.Dto
{
    public class GetEtInput : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
