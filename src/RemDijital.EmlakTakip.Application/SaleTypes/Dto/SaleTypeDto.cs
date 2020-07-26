using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.SaleTypes.Dto
{
    [AutoMapFrom(typeof(SaleType))]
    public class SaleTypeDto: EntityDto<int>, IMustHaveTenant
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
