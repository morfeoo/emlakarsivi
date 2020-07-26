using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using RemDijital.EmlakTakip.SaleTypes.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Timing;
using System.Linq;
using RemDijital.EmlakTakip.Authorization;
using Abp.Authorization;

namespace RemDijital.EmlakTakip.SaleTypes
{
    //[AbpAuthorize(PermissionNames.Pages_SaleTypes)]
    public class SaleTypeAppService : AsyncCrudAppService<SaleType, SaleTypeDto, int, GetSaleTypeInput>, ISaleTypeAppService
    {
        private readonly IAbpSession _session;
        public SaleTypeAppService(IRepository<SaleType, int> repository, IAbpSession session) : base(repository)
        {
            _session = session;
        }
        public async Task<PagedResultDto<SaleTypeDto>> Filter(GetSaleTypeInput input)
        {
            try
            {
                var t = _session.GetTenantId();
                var a = await Repository.GetAllListAsync();
                var x = a.Where(r => r.TenantId == t).WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.ToLower().Contains(input.Keyword.ToLower()));
                var b = x.Skip(input.SkipCount).Take(input.MaxResultCount);
                return new PagedResultDto<SaleTypeDto>
                {
                    TotalCount = x.Count(),
                    Items = ObjectMapper.Map<List<SaleTypeDto>>(b)
                };
            }
            catch (Exception ex)
            {
                return new PagedResultDto<SaleTypeDto>
                {
                    TotalCount = 0,
                    Items = null
                };
            }
        }
        public async Task<bool> EtCreate(CreateSaleTypeInput input)
        {
            try
            {
                var et = new SaleType
                {
                    CreationTime = Clock.Now,
                    CreatorUserId = _session.GetUserId(),
                    Name = input.Name,
                    TenantId = _session.GetTenantId()
                };
                await Repository.InsertAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> EtUpdate(SaleTypeDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                et.Name = input.Name;
                et.LastModificationTime = Clock.Now;
                et.LastModifierUserId = _session.GetUserId();
                await Repository.UpdateAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<SaleTypeDto> GetEtDtoForEdit(EntityDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                return ObjectMapper.Map<SaleTypeDto>(et);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> EtDelete(EntityDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                await Repository.DeleteAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<ListResultDto<ComboboxItemDto>> GetCitiesSaleTypesComboboxItems()
        {
            var people = await Repository.GetAllListAsync();
            return new ListResultDto<ComboboxItemDto>(
                people.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.Name)).ToList()
            );
        }

        public async Task<List<SaleType>> GetAllsaleTypes()
        {
            return await Repository.GetAllListAsync();
        }
 
        public Task<PagedResultDto<SaleTypeDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}
