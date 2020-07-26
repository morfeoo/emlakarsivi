using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RemDijital.EmlakTakip.Cities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Cities
{
    public interface ICityAppService : IAsyncCrudAppService<CityDto>
    {
        Task<List<City>> GetAllCities();
        Task<ListResultDto<ComboboxItemDto>> GetCitiesComboboxItems();
    }
}
