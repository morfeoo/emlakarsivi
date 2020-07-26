using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.EstateTypes
{
    public class EstateType : FullAuditedEntity , IMustHaveTenant
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
