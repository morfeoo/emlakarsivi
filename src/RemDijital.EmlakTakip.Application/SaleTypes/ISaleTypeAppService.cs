using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RemDijital.EmlakTakip.SaleTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.SaleTypes
{
    public interface ISaleTypeAppService : IAsyncCrudAppService<SaleTypeDto>
    {
        Task<List<SaleType>> GetAllsaleTypes();
        Task<ListResultDto<ComboboxItemDto>> GetCitiesSaleTypesComboboxItems();
        Task<SaleTypeDto> GetEtDtoForEdit(EntityDto input);
    }
}
