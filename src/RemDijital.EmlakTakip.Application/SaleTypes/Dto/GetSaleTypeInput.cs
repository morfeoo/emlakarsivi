using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.SaleTypes.Dto
{
    public class GetSaleTypeInput : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
