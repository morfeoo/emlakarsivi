using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace RemDijital.EmlakTakip.Estates
{
    public class Estate : FullAuditedEntity, IMustHaveTenant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstateTypeId { get; set; }
        public int SaleTypeId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int MahalleId { get; set; }
        public int Meter { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int TenantId { get; set; }
    }
}