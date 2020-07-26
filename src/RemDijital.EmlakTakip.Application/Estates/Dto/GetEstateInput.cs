using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Estates.Dto
{
    public class GetEstateInput : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public int SaleTypeId { get; set; }
        public int EstateTypeId { get; set; }
    }
}
