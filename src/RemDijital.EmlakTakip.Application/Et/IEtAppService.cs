using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RemDijital.EmlakTakip.EstateTypes;
using RemDijital.EmlakTakip.Et.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Et
{
    public interface IEtAppService : IAsyncCrudAppService<EtDto>
    {
        Task<List<EstateType>> GetAllEstateTypes();
        Task<ListResultDto<ComboboxItemDto>> GetEstateTypeComboboxItems();
        Task<EtDto> GetEtDtoForEdit(EntityDto input);
    }
}
