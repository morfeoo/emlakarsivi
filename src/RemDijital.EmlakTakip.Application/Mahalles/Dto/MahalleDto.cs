using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Mahalles.Dto
{
    [AutoMapFrom(typeof(Mahalle))]
    public class MahalleDto : EntityDto<int>
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
