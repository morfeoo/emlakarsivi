using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RemDijital.EmlakTakip.EstateTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Et.Dto
{
    public class CreateEtInput
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
