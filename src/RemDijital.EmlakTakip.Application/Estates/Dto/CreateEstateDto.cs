using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Estates.Dto
{
    public class CreateEstateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstateTypeId { get; set; }
        public int SaleTypeId { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int TenantId { get; set; }
    }
}
