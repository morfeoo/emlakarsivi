using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Districts
{
    public class District : FullAuditedEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
