using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Mahalles
{
    public class Mahalle : FullAuditedEntity
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }
}
