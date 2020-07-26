using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using RemDijital.EmlakTakip.Cities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Cities
{
    public class CityAppService : AsyncCrudAppService<City, CityDto , int , GetCityInput> , ICityAppService
    {
        public CityAppService(IRepository<City, int> repository) : base(repository)
        {
        }

        //[Obsolete]
        public async Task<PagedResultDto<CityDto>> Filter(GetCityInput input)
        {
            //return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.Contains(input.Keyword));
            var a = await Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.Contains(input.Keyword)).ToListAsync();
            var b = a.Skip(input.SkipCount).Take(input.MaxResultCount);
            return new PagedResultDto<CityDto>
            {
                TotalCount = a.Count(),
                Items = ObjectMapper.Map<List<CityDto>>(b)
            };
            //return new PagedResultDto<CityDto>(b.Count(), IQueryable<CityDto>);
        }

        public Task<PagedResultDto<CityDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
        public async Task<List<City>> GetAllCities()
        {
            return await Repository.GetAllListAsync();
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetCitiesComboboxItems()
        {
            var people = await Repository.GetAllListAsync();
            return new ListResultDto<ComboboxItemDto>(
                people.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.Name)).ToList()
            );
        }
        protected override IQueryable<City> CreateFilteredQuery(GetCityInput input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.Contains(input.Keyword));
        }
    }
}
