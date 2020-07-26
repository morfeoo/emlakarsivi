using Abp.Application.Services;
using RemDijital.EmlakTakip.EstateTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.EstateTypes
{
    public interface IEstateTypeAppService : IAsyncCrudAppService<EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEstateTypeDto, EstateTypeDto>
    { }
    
}
