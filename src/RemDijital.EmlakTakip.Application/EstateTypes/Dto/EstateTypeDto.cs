using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.EstateTypes.Dto
{
    [AutoMapFrom(typeof(EstateType))]
    public class EstateTypeDto : EntityDto
    {
        public string Name { get; set; }
        public int TenantId { get; set; }

    }
}
