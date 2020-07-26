using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Cities.Dto
{
    public class GetCityInput : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
