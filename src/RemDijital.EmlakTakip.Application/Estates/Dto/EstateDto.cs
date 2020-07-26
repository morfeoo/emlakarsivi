using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Estates.Dto
{
    [AutoMapFrom(typeof(Estate))]
    public class EstateDto : EntityDto, IMustHaveTenant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int TenantId { get; set; }
        public int CreatorUserId { get; set; }
    }
}
