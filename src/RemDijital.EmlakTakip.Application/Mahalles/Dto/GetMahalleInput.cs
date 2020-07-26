using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Mahalles.Dto
{
    public class GetMahalleInput : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
