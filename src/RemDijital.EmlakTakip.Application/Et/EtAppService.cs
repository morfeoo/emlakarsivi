using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using RemDijital.EmlakTakip.EstateTypes;
using RemDijital.EmlakTakip.Et.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Et
{
    public class EtAppService : AsyncCrudAppService<EstateType, EtDto, int, GetEtInput>, IEtAppService
    {
        private readonly IAbpSession _session;

        public EtAppService(IRepository<EstateType, int> repository, IAbpSession session) : base(repository)
        {
            _session = session;
        }
        public async Task<PagedResultDto<EtDto>> Filter(GetEtInput input)
        {
            try
            {
                var t = _session.GetTenantId();
                var a = await Repository.GetAllListAsync();
                var x = a.Where(r => r.TenantId == t).WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.ToLower().Contains(input.Keyword.ToLower()));
                var b = x.Skip(input.SkipCount).Take(input.MaxResultCount);
                return new PagedResultDto<EtDto>
                {
                    TotalCount = x.Count(),
                    Items = ObjectMapper.Map<List<EtDto>>(b)
                };
            }
            catch (Exception ex)
            {
                return new PagedResultDto<EtDto>
                {
                    TotalCount = 0,
                    Items = null
                };
            }
        }
        public async Task<bool> EtCreate(CreateEtInput input)
        {
            try
            {
                var et = new EstateType
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
        public async Task<bool> EtUpdate(EtDto input)
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
        public async Task<EtDto> GetEtDtoForEdit(EntityDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                return ObjectMapper.Map<EtDto>(et);
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
        public async Task<ListResultDto<ComboboxItemDto>> GetEstateTypeComboboxItems()
        {
            var people = await Repository.GetAllListAsync();
            return new ListResultDto<ComboboxItemDto>(
                people.Select(p => new ComboboxItemDto(p.Id.ToString("D"), p.Name)).ToList()
            );
        }
        public async Task<List<EstateType>> GetAllEstateTypes()
        {
            return await Repository.GetAllListAsync();
        }
        public Task<PagedResultDto<EtDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}
