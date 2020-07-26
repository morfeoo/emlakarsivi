using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.EstateTypes.Dto
{
    [AutoMapTo(typeof(EstateType))]
    public class CreateEstateTypeDto
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
