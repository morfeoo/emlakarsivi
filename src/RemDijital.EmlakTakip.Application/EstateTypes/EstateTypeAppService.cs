using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using RemDijital.EmlakTakip.Authorization;
using RemDijital.EmlakTakip.EstateTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.EstateTypes
{
    //[AbpAuthorize(PermissionNames.Pages_EstateTypes)]
    public class EstateTypeAppService : AsyncCrudAppService<EstateType, EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEstateTypeDto, EstateTypeDto>, IEstateTypeAppService
    {
        private readonly IAbpSession _session;
        public EstateTypeAppService(IRepository<EstateType, int> repository, IAbpSession session) : base(repository)
        {
            _session = session;
        }
        protected override IQueryable<EstateType> CreateFilteredQuery(PagedEstateTypeResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),x=>x.Name.Contains(input.Keyword));
        }
        public async Task<PagedResultDto<EstateTypeDto>> Filter(PagedEstateTypeResultRequestDto input)
        {
            //return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.Contains(input.Keyword));
            var a = await Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.ToLower().Contains(input.Keyword.ToLower())).ToListAsync();
            var b = a.Skip(input.SkipCount).Take(input.MaxResultCount);
            return new PagedResultDto<EstateTypeDto>
            {
                TotalCount = a.Count(),
                Items = ObjectMapper.Map<List<EstateTypeDto>>(b)
            };
            //return new PagedResultDto<CityDto>(b.Count(), IQueryable<CityDto>);
        }
    }
}
