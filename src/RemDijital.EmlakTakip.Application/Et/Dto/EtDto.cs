using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using RemDijital.EmlakTakip.EstateTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Et.Dto
{
    [AutoMapFrom(typeof(EstateType))]
    public class EtDto : EntityDto<int>, IMustHaveTenant
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
