using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Cities
{
    public class City : FullAuditedEntity
    {
        public string Name { get; set; }
    }
}
